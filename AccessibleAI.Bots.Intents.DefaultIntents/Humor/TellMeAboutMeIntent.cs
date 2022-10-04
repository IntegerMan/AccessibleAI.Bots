using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class TellMeAboutMeIntent : ChitChatIntentBase
{
    public TellMeAboutMeIntent(string intentName = "TellMeAboutMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not really programmed with information about you.");
    }
}
