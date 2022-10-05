namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class BeFunnyIntent : ChitChatIntentBase
{
    public BeFunnyIntent(string intentName = "BeFunny") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not sure I can be funny on command.");
    }
}
