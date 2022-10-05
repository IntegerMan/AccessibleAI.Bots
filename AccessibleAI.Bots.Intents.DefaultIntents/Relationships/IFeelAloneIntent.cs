namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class IFeelAloneIntent : ChitChatIntentBase
{
    public IFeelAloneIntent(string intentName = "IFeelAlone") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry to hear that.");
    }
}


