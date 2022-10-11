namespace AccessibleAI.Bots.Intents.DefaultIntents.Positive;

public class YouAreSmartIntent : ChitChatIntentBase
{
    public YouAreSmartIntent(string intentName = "YouAreSmart") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm glad I can be helpful.");
    }
}
