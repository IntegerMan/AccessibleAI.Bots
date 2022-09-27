using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class BeQuietIntent : ChitChatIntentBase
{
    public BeQuietIntent(string intentName = "BeQuiet") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'll be here if you want to talk.");
    }
}
