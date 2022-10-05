namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhoMadeYouIntent : ChitChatIntentBase
{
    public WhoMadeYouIntent(string intentName = "WhoMadeYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't know who made me, but I use parts from the Accessible AI Bots Project.");
    }
}
