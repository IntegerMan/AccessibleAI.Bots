namespace AccessibleAI.Bots.Intents.DefaultIntents.Body;

public class ImHungryIntent : ChitChatIntentBase
{
    public ImHungryIntent(string intentName = "ImHungry") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Maybe it's time to step away and have some food.");
    }
}
