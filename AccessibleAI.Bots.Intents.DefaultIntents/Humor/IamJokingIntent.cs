using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class IamJokingIntent : ChitChatIntentBase
{
    public IamJokingIntent(string intentName = "IamJoking") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Ha!");
    }
}
