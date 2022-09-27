using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class HelloIntent : ChitChatIntentBase
{
    public HelloIntent(string intentName = "Hello") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Hello!");
    }
}
