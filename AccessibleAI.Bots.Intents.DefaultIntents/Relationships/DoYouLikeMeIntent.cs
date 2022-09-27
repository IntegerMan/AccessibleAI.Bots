using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class DoYouLikeMeIntent : ChitChatIntentBase
{
    public DoYouLikeMeIntent(string intentName = "DoYouLikeMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I like everyone.");
    }
}
