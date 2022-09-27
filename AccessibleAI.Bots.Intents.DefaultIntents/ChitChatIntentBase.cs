using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public abstract class ChitChatIntentBase : IntentHandlerBase
{
    protected ChitChatIntentBase(string intentName) : base(intentName, "ChitChat")
    {
    }
}
