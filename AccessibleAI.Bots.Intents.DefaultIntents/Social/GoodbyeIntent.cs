using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class GoodbyeIntent : ChitChatIntentBase
{
    public GoodbyeIntent(string intentName = "Goodbye") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Bye!");
    }
}
