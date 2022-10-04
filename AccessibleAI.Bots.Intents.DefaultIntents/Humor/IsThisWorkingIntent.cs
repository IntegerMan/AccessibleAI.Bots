using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class IsThisWorkingIntent : ChitChatIntentBase
{
    public IsThisWorkingIntent(string intentName = "IsThisWorking") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm getting your messages just fine.");
    }
}
