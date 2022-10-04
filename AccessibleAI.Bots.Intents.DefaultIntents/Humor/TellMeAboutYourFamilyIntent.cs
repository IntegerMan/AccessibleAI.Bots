using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class TellMeAboutYourFamilyIntent : ChitChatIntentBase
{
    public TellMeAboutYourFamilyIntent(string intentName = "TellMeAboutYourFamily") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't have a family; I'm a bot.");
    }
}
