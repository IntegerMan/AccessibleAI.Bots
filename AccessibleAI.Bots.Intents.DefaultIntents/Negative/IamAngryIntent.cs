namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class IamAngryIntent : ChitChatIntentBase
{
    public IamAngryIntent(string intentName = "IamAngry") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry to hear you're angry.");
    }
}
