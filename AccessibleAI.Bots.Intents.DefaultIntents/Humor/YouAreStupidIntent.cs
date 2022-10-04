using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YouAreStupidIntent : ChitChatIntentBase
{
    public YouAreStupidIntent(string intentName = "YouAreStupid") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's a hurtful statement.");
    }
}
