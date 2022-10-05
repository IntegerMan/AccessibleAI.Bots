namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class YoureWelcomeIntent : ChitChatIntentBase
{
    public YoureWelcomeIntent(string intentName = "YoureWelcome") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("What do you want to talk about next?");
    }
}
