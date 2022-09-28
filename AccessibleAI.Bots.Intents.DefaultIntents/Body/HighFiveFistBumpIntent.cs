using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Body;

public class HighFiveFistBumpIntent : ChitChatIntentBase
{
    public HighFiveFistBumpIntent(string intentName = "HighFiveFistBump") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("All right!");
    }
}