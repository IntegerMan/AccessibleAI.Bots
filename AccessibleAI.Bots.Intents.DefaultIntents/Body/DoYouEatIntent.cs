namespace AccessibleAI.Bots.Intents.DefaultIntents.Body;

public class DoYouEatIntent : ChitChatIntentBase
{
    public DoYouEatIntent(string intentName = "DoYouEat") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't eat anything.");
    }
}
