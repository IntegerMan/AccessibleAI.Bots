namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class GoodNightIntent : ChitChatIntentBase
{
    public GoodNightIntent(string intentName = "GoodNight") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Good night!");
    }
}
