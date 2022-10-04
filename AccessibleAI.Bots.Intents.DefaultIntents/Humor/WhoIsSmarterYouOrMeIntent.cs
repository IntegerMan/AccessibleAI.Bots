using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WhoIsSmarterYouOrMeIntent : ChitChatIntentBase
{
    public WhoIsSmarterYouOrMeIntent(string intentName = "WhoIsSmarterYouOrMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not very smart. Most animals are smarter than I am.");
    }
}
