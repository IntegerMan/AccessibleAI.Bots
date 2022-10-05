namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class YouHateMeIntent : ChitChatIntentBase
{
    public YouHateMeIntent(string intentName = "YouHateMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I assure you that I don't hate you.");
    }
}
