namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class YouAreUglyIntent : ChitChatIntentBase
{
    public YouAreUglyIntent(string intentName = "YouAreUgly") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's cruel.");
    }
}
