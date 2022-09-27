using AccessibleAI.Bots.Core.Language.Intents;
using System.Threading.Tasks;

namespace AccessibleAI.Bots.Core.Intents;

public abstract class IntentHandlerBase : IIntentHandler
{
    protected IntentHandlerBase(string intentName, string orchestrationName = "None")
    {
        IntentName = intentName;
        OrchestrationName = orchestrationName;
    }

    public string IntentName { get; }
    public string OrchestrationName { get; }

    public abstract Task ReplyAsync(ConversationContext context);

    /// <inheritdoc />
    public override string ToString() => Key;

    public string Key => $"{OrchestrationName}/{IntentName}";
}