using System.Threading;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Core.Intents;

public abstract class IntentHandlerBase
{
    protected IntentHandlerBase(string intentName, string? triggerPhrase)
    {
        IntentName = intentName.ToUpperInvariant();
        TriggerPhrase = triggerPhrase;
    }

    public string? TriggerPhrase { get; }

    public string IntentName { get; }

    public abstract Task ReplyAsync(ITurnContext context, LanguageResult intent, CancellationToken token);
}