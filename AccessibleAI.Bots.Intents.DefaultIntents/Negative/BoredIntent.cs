namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class BoredIntent : ChitChatIntentBase
{
    public BoredIntent(string intentName = "IamBored") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("If you're bored you may want to try something else.");
    }
}
