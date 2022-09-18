using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Blobs
{
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
            // Create the append blob in a folder for the year, month, and day.
            // This makes it easier to automatically delete old log folders
            DateTime today = DateTime.Today;
            AppendBlobClient client = new(_storageConnStr, _storageContainerName, $"{today.Year}/{today.Month}/{today.Day}/{activity.ChannelId}/{activity.Conversation.Id}.txt");
            await client.CreateIfNotExistsAsync();

            // This is always an Activity in this app, so we're fine to use that
            Activity actualActivity = (Activity)activity;

            // Build the message to log
            string message;
            message = activity.LocalTimestamp != null 
                ? $"{activity.From.Name} @ {activity.LocalTimestamp.Value:G} {Environment.NewLine}{actualActivity.Text}{Environment.NewLine}{Environment.NewLine}" 
                : $"{activity.From.Name} {Environment.NewLine}{actualActivity.Text}{Environment.NewLine}{Environment.NewLine}";

            // Actually append it to the blob
            using (Stream stream = ToStream(message))
            {
                await client.AppendBlockAsync(stream);
            }
        }
    }

}
