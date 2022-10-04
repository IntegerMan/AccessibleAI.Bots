using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Positive;

public class YouAreRightIntent : ChitChatIntentBase
{
    public YouAreRightIntent(string intentName = "YouAreRight") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Wonderful. How else can I help you?");
    }
}
