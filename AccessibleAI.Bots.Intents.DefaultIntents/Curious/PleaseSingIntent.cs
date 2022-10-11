namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class PleaseSingIntent : ChitChatIntentBase
{
    public PleaseSingIntent(string intentName = "PleaseSingToMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I can't sing.");
    }
}
