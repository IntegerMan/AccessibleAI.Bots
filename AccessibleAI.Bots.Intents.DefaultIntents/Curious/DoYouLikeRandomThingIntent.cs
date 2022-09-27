using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class DoYouLikeRandomThingIntent : ChitChatIntentBase
{
    public DoYouLikeRandomThingIntent(string intentName = "DoYouLikeRandomThing") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I really don't have many preferences programmed into me.");
    }
}
