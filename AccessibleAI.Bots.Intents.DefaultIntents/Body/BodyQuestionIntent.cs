using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Body;

public class BodyQuestionIntent : ChitChatIntentBase
{
    public BodyQuestionIntent(string intentName = "BodyQuestion") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, but I don't have a body.");
    }
}
