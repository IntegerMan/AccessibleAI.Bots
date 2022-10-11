namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class GoodMorningIntent : ChitChatIntentBase
{
    public GoodMorningIntent(string intentName = "GoodMorning") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Good morning!");
    }
}
