namespace AccessibleAI.Bots.Intents.DefaultIntents.Positive;

public class ThatWasGoodIntent : ChitChatIntentBase
{
    public ThatWasGoodIntent(string intentName = "ThatWasGood") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Great!");
    }
}
