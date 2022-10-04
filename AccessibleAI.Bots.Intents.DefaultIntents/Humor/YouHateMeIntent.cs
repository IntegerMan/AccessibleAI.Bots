using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YouHateMeIntent : ChitChatIntentBase
{
    public YouHateMeIntent(string intentName = "YouHateMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I assure you that I don't hate you.");
    }
}
