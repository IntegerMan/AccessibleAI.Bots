using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class SadIntent : ChitChatIntentBase
{
    public SadIntent(string intentName = "IamSad") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry you're sad right now.");
    }
}
