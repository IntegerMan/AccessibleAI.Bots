using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class DoILookNiceIntent : ChitChatIntentBase
{
    public DoILookNiceIntent(string intentName = "DoILookNice") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't have eyes, but I'm sure you're fine.");
    }
}
