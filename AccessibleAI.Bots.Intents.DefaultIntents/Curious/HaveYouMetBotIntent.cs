using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class HaveYouMetBotIntent : ChitChatIntentBase
{
    public HaveYouMetBotIntent(string intentName = "HaveYouMetBot") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I actually don't get to meet any other bots.");
    }
}
