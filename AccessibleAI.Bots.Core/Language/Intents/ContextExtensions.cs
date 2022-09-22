using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Core.Intents;

// TODO: This really needs a larger wrapper context object to hold the TurnContext, cancellationToken, logger, and other potentially useful things.

public static class ContextExtensions
{
    public static async Task ErrorReplyAsync(this ConversationContext context, string message, IEnumerable<string>? suggestedActions = null)
    {
        // TODO: Error logging!

        await context.ReplyAsync(message, suggestedActions: suggestedActions);
    }
    public static async Task ReplyAsync(this ConversationContext context, string message, IEnumerable<string>? suggestedActions = null)
    {
        await context.TypeReplyAsync(message, delayPerCharacter: 0, suggestedActions: suggestedActions);
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public static async Task<ResourceResponse[]> TypeReplyAsync(this ConversationContext context,
        string? message,
        int delayPerCharacter = 5,
        IEnumerable<string>? suggestedActions = null)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return Array.Empty<ResourceResponse>();
        }

        List<IActivity> activities = new();

        // Include the typing delay
        if (delayPerCharacter > 0)
        {
            activities.Add(new Activity(type: ActivityTypes.Typing, text: null));
            activities.Add(new Activity(type: ActivityTypes.Delay, value: message.Length * delayPerCharacter));
        }

        // Include the message
        if (suggestedActions != null && suggestedActions.Any())
        {
            activities.Add(MessageFactory.SuggestedActions(suggestedActions, message));
        }
        else
        {
            activities.Add(MessageFactory.Text(message));
        }

        // Send the actions
        return await context.TurnContext.SendActivitiesAsync(activities.ToArray(), context.CancellationToken);
    }

    public static async Task SendThumbnailAsync(this ConversationContext context, CardInformation cardInfo, int delay = 350)
    {
        List<CardImage> images = new() { new CardImage(cardInfo.ImageUrl, cardInfo.ImageAltText) };
        ThumbnailCard card = new(cardInfo.Title, cardInfo.Subtitle, cardInfo.Text, images, cardInfo.Actions);

        IMessageActivity attachment = MessageFactory.Attachment(card.ToAttachment());

        await context.TurnContext.SendAttachmentAsync(attachment, context.CancellationToken, delay);
    }

    public static async Task SendHeroAsync(this ConversationContext context, CardInformation cardInfo, int delay = 500)
    {
        HeroCard card = CreateHeroCard(cardInfo);
        IMessageActivity attachment = MessageFactory.Attachment(card.ToAttachment());

        await context.TurnContext.SendAttachmentAsync(attachment, context.CancellationToken, delay);
    }

    private static HeroCard CreateHeroCard(CardInformation cardInfo)
    {
        List<CardImage> images = new() { new CardImage(cardInfo.ImageUrl, cardInfo.ImageAltText) };
        HeroCard card = new(cardInfo.Title, cardInfo.Subtitle, cardInfo.Text, images, cardInfo.Actions);
        return card;
    }

    public static Task SendCarouselAsync(this ConversationContext context,
        IEnumerable<CardInformation> cards, int delay = 500)
    {
        return context.SendCarouselAsync(null, cards, delay);
    }

    public static async Task SendCarouselAsync(this ConversationContext context,
        string? text,
        IEnumerable<CardInformation> cards, int delay = 500)
    {
        List<Attachment> attachments = new();
        foreach (CardInformation card in cards)
        {
            HeroCard heroCard = CreateHeroCard(card);
            attachments.Add(heroCard.ToAttachment());
        }

        List<IActivity> activities = new();

        // Include the typing delay
        if (delay > 0)
        {
            activities.Add(new Activity(type: ActivityTypes.Typing, text: null));
            activities.Add(new Activity(type: ActivityTypes.Delay, value: delay));
        }

        activities.Add(MessageFactory.Carousel(attachments, text));

        await context.TurnContext.SendActivitiesAsync(activities.ToArray(), context.CancellationToken);
    }

    public static async Task SendAttachmentAsync(this ITurnContext context, IMessageActivity attachment, CancellationToken token, int delay = 500)
    {
        List<IActivity> activities = new();

        // Include the typing delay
        if (delay > 0)
        {
            activities.Add(new Activity(type: ActivityTypes.Typing, text: null));
            activities.Add(new Activity(type: ActivityTypes.Delay, value: delay));
        }

        activities.Add(attachment);

        await context.SendActivitiesAsync(activities.ToArray(), token);
    }

    public static bool IsEmulator(this ITurnContext context) => context.Activity.ChannelId == "emulator";
}