namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class BoringIntent : ChitChatIntentBase
{
    public BoringIntent(string intentName = "Boring") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm only as interesting as I was made to be.");
    }
}
