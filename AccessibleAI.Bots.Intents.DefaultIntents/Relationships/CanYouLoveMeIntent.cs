using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class CanYouLoveMeIntent : ChitChatIntentBase
{
    public CanYouLoveMeIntent(string intentName = "CanYouLoveMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, I can't talk about love.");
    }
}
