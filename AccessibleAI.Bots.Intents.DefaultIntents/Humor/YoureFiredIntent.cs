using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YoureFiredIntent : ChitChatIntentBase
{
    public YoureFiredIntent(string intentName = "YoureFired") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's unfortunate.");
    }
}
