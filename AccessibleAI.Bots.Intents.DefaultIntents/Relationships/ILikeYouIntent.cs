namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class ILikeYouIntent : ChitChatIntentBase
{
    public ILikeYouIntent(string intentName = "ILikeYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's nice.");
    }
}
