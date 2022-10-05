namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class WhoIsSmarterYouOrMeIntent : ChitChatIntentBase
{
    public WhoIsSmarterYouOrMeIntent(string intentName = "WhoIsSmarterYouOrMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not very smart. Most animals are smarter than I am.");
    }
}
