namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class HappyHolidayIntent : ChitChatIntentBase
{
    public HappyHolidayIntent(string intentName = "HappyHoliday") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("And to you as well!");
    }
}
