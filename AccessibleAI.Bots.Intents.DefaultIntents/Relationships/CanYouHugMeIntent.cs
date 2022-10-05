namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class CanYouHugMeIntent : ChitChatIntentBase
{
    public CanYouHugMeIntent(string intentName = "CanYouHugMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Here's a hug for you.");
    }
}
