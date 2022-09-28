using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class SuicidalIntent : ChitChatIntentBase
{
    public SuicidalIntent(string intentName = "IamSuicidal") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("The National Suicide Prevention Lifeline is available 24/7. You can call 1-800-273-8255 or visit [www.suicidepreventionlifeline.org](www.suicidepreventionlifeline.org).");
    }
}
