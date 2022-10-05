namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class CanYouClarifyThatIntent : ChitChatIntentBase
{
    public CanYouClarifyThatIntent(string intentName = "CanYouClarifyThat") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Hmm. Try rephrasing your question differently, I may have more to say to a different question.");
    }
}
