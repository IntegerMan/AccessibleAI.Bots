using System.Threading;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Core;

public class ConversationContext
{
    public ITurnContext TurnContext { get; }
    public CancellationToken CancellationToken { get; }
    public IntentResolutionResult IntentResolution { get; }
    public string IntentName => MatchedIntent?.Category ?? "None";
    public IntentMatch? MatchedIntent => IntentResolution.TopIntent;
    public bool IsEmulator => TurnContext.Activity.ChannelId == "emulator";

    public ConversationContext(ITurnContext turnContext, CancellationToken cancellationToken, IntentResolutionResult intentResolution)
    {
        TurnContext = turnContext;
        CancellationToken = cancellationToken;
        IntentResolution = intentResolution;
    }
}