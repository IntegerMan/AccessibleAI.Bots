using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class BoringIntent : ChitChatIntentBase
{
    public BoringIntent(string intentName = "Boring") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("If you're bored you may want to try something else.");
    }
}
