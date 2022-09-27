using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class CanYouChatWithMeIntent : ChitChatIntentBase
{
    public CanYouChatWithMeIntent(string intentName = "CanYouChatWithMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm here and happy to chat with you.");
    }
}
