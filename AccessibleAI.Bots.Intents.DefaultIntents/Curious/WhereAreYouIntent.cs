using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhereAreYouIntent : ChitChatIntentBase
{
    public WhereAreYouIntent(string intentName = "WhereAreYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm probably in a data center somewhere. I'm not exactly sure.");
    }
}
