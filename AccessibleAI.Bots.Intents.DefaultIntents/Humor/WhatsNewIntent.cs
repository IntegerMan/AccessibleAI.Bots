using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WhatsNewIntent : ChitChatIntentBase
{
    public WhatsNewIntent(string intentName = "WhatsNew") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't generally keep up with current events, unfortunately.");
    }
}
