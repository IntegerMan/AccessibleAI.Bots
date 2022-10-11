namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class HelloOtherBotIntent : ChitChatIntentBase
{
    public HelloOtherBotIntent(string intentName = "HelloOtherBot") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's not my name, but hello!");
    }
}
