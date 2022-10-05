namespace AccessibleAI.Bots.Intents.DefaultIntents.Positive;

public class MiscPositiveIntent : ChitChatIntentBase
{
    public MiscPositiveIntent(string intentName = "MiscPositive") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's nice.");
    }
}
