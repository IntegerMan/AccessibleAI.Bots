using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class AreYouABotIntent : IntentHandlerBase
{
    public AreYouABotIntent(string intentName = "AreYouABot", string orchestrationName = "ChitChat") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Of course I'm a bot. I was built using the Microsoft Bot Framework with added components from the Accessible AI Bots project.");
    }
}
