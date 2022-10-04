using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class PleaseSingIntent : ChitChatIntentBase
{
    public PleaseSingIntent(string intentName = "PleaseSingToMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I can't sing.");
    }
}
