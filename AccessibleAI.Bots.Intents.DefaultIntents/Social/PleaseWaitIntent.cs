using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class PleaseWaitIntent : ChitChatIntentBase
{
    public PleaseWaitIntent(string intentName = "PleaseWait") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm happy to wait. Just let me know what you'd like to talk about next when you're ready.");
    }
}
