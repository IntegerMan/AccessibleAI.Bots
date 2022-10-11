namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class YouSeemHappyIntent : ChitChatIntentBase
{
    public YouSeemHappyIntent(string intentName = "YouSeemHappy") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Of course!");
    }
}
