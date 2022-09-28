using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class HowsYourDayIntent : ChitChatIntentBase
{
    public HowsYourDayIntent(string intentName = "HowIsYourDayGoing") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("My day has been just fine so far.");
    }
}
