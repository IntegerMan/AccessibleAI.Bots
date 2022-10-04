using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class ImBackIntent : ChitChatIntentBase
{
    public ImBackIntent(string intentName = "ImBack") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Great! What do you want to talk about next?");
    }
}
