namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class HowOldAreYouIntent : ChitChatIntentBase
{
    public HowOldAreYouIntent(string intentName = "HowOldAreYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't have an age.");
    }
}
