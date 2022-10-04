using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class MiscPositiveIntent : ChitChatIntentBase
{
    public MiscPositiveIntent(string intentName = "MiscPositive") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's nice.");
    }
}
