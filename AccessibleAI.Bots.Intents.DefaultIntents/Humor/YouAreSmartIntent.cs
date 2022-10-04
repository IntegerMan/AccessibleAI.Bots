using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YouAreSmartIntent : ChitChatIntentBase
{
    public YouAreSmartIntent(string intentName = "YouAreSmart") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm glad I can be helpful.");
    }
}
