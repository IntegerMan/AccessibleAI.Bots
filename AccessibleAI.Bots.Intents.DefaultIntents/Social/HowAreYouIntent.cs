using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class HowAreYouIntent : ChitChatIntentBase
{
    public HowAreYouIntent(string intentName = "HowAreYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm fine, thanks!");
    }
}
