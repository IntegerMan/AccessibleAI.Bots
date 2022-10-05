namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class GoodEveningIntent : ChitChatIntentBase
{
    public GoodEveningIntent(string intentName = "GoodEvening") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Good evening!");
    }
}
