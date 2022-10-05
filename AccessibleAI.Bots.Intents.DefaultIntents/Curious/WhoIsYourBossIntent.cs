namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhoIsYourBossIntent : ChitChatIntentBase
{
    public WhoIsYourBossIntent(string intentName = "WhoIsYourBoss") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't know.");
    }
}
