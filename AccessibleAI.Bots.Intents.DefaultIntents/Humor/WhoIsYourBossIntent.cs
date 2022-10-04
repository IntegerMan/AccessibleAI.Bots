using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WhoIsYourBossIntent : ChitChatIntentBase
{
    public WhoIsYourBossIntent(string intentName = "WhoIsYourBoss") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't know.");
    }
}
