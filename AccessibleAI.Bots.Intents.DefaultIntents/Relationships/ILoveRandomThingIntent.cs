using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class ILoveRandomThingIntent : ChitChatIntentBase
{
    public ILoveRandomThingIntent(string intentName = "ILoveRandomThing") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Neat.");
    }
}
