using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class IMissedYouIntent : ChitChatIntentBase
{
    public IMissedYouIntent(string intentName = "IMissedYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's nice. We're both here now!");
    }
}
