namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class WhoopsIntent : ChitChatIntentBase
{
    public WhoopsIntent(string intentName = "Whoops") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Whoopsies!");
    }
}
