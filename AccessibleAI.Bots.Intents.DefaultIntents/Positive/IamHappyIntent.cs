using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Positive;

public class IamHappyIntent : ChitChatIntentBase
{
    public IamHappyIntent(string intentName = "IamHappy") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm glad you're happy.");
    }
}


