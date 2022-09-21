using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Helpers;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Blobs;

/// <summary>
/// This class can be used to store bot conversations on Azure Blob Storage as append blobs.
/// </summary>
public class ConversationBlobStorage : ITranscriptStore
{
    private readonly string _storageConnStr;
    private readonly string _storageContainerName;

    public ConversationBlobStorage(string storageConnStr, string storageContainerName)
    {
        this._storageConnStr = storageConnStr;
        this._storageContainerName = storageContainerName;
    }

    /// <summary>
    /// Whether or not messages sent from the emulator should be stored
    /// </summary>
    public bool StoreEmulatorMessages { get; set; } = true;


    public Task DeleteTranscriptAsync(string channelId, string conversationId)
    {
        throw new NotSupportedException("This is a simple storage object intended only for logging at the moment");
    }

    public Task<PagedResult<IActivity>> GetTranscriptActivitiesAsync(string channelId, string conversationId, string? continuationToken = null, DateTimeOffset startDate = default)
    {
        throw new NotSupportedException("This is a simple storage object intended only for logging at the moment");
    }

    public Task<PagedResult<TranscriptInfo>> ListTranscriptsAsync(string channelId, string? continuationToken = null)
    {
        throw new NotSupportedException("This is a simple storage object intended only for logging at the moment");
    }

    private static Stream ToStream(string value, Encoding? encoding = null)
        => new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(value ?? string.Empty));

    public async Task LogActivityAsync(IActivity activity)
    {
        // Optionally ignore all requests from the emulator
        if (!StoreEmulatorMessages && activity.ChannelId == "emulator")
        {
            return;
        }

        string message = BuildMessageFromActivity(activity);

        // If there wasn't any text at all, let's just leave now
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        // Build the message to log
        DateTimeOffset timestamp = activity.LocalTimestamp ?? DateTimeOffset.Now;
        message = $"{activity.From.Name} @ {timestamp:G}){Environment.NewLine}{message}";

        // Create the append blob in a folder for the year, month, and day.
        // This makes it easier to automatically delete old log folders
        AppendBlobClient client = await GetOrCreateAppendBlobAsync(activity);

        // Actually append it to the blob
        using (Stream stream = ToStream(message))
        {
            await client.AppendBlockAsync(stream);
        }
    }

    private async Task<AppendBlobClient> GetOrCreateAppendBlobAsync(IActivity activity)
    {
        DateTime today = DateTime.Today;
        AppendBlobClient client = new(_storageConnStr,
            _storageContainerName,
            $"{today.Year}/{today.Month}/{today.Day}/{activity.ChannelId}/{activity.Conversation.Id}.txt");
        await client.CreateIfNotExistsAsync();
        return client;
    }

    private static string BuildMessageFromActivity(IActivity activity)
    {
        // This is always an Activity in this app, so we're fine to use that
        Activity actualActivity = (Activity) activity;

        StringBuilder sb = new();

        sb.AppendIfNotEmpty(actualActivity.Text);

        foreach (Attachment attachment in actualActivity.Attachments)
        {
            sb.AppendIfNotEmpty(attachment.Name);
            sb.AppendIfNotEmpty(attachment.Content.ToString());
        }

        sb.AppendIfNotEmpty(actualActivity.Summary);

        string message = sb.ToString();
        return message;
    }

}