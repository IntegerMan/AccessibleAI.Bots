namespace AccessibleAI.Bots.Intents.DefaultIntents.Body;

public class IamTiredIntent : ChitChatIntentBase
{
    public IamTiredIntent(string intentName = "IamTired") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Naps are nice.");
    }
}


