using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class YoureNotHelpfulIntent : ChitChatIntentBase
{
    public YoureNotHelpfulIntent(string intentName = "YoureNotHelpful") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry to hear that.");
    }
}
