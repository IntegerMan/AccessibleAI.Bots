using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class ImSorryIntent : ChitChatIntentBase
{
    public ImSorryIntent(string intentName = "ImSorry") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Ok. What do you want to do next?");
    }
}
