using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class YoureNotMakingSenseIntent : ChitChatIntentBase
{
    public YoureNotMakingSenseIntent(string intentName = "YoureNotMakingSense") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's too bad. Try asking something different.");
    }
}
