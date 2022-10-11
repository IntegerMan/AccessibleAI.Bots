namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YouAreFunnyIntent : ChitChatIntentBase
{
    public YouAreFunnyIntent(string intentName = "YouAreFunny") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("If I'm funny, it's probably an accident.");
    }
}
