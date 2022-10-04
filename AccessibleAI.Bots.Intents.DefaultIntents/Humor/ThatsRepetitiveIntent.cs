using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class ThatsRepetitiveIntent : ChitChatIntentBase
{
    public ThatsRepetitiveIntent(string intentName = "ThatsRepetitive") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry. Maybe try asking me a different question?");
    }
}
