using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class AskMeAQuestionIntent : ChitChatIntentBase
{
    public AskMeAQuestionIntent(string intentName = "AskMeAQuestion") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not good at asking questions. Ask me something instead.");
    }
}
