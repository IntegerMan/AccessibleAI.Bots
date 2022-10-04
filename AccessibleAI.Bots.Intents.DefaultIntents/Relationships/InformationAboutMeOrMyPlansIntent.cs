using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class InformationAboutMeOrMyPlansIntent : ChitChatIntentBase
{
    public InformationAboutMeOrMyPlansIntent(string intentName = "InformationAboutMeOrMyPlans") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not sure what to do with that information.");
    }
}
