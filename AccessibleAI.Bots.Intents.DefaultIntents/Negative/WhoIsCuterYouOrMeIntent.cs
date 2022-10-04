using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class WhoIsCuterYouOrMeIntent : ChitChatIntentBase
{
    public WhoIsCuterYouOrMeIntent(string intentName = "WhoIsCuterYouOrMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I cannot see you and I have no appearance.");
    }
}
