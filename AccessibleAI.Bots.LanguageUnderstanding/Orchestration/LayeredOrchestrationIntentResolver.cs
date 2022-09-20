using System.Collections.Generic;
using System.Linq;
using AccessibleAI.Bots.Core.Language;

namespace AccessibleAI.Bots.LanguageUnderstanding.Orchestration;

/// <summary>
/// This class is a layer-based approach to orchestrating multiple IntentResolvers by priority.
///
/// This is a manual alternative to orchestration workflows that helps with class imbalances between orchestration layers and
/// allows you to set a priority order for each layer. This allows critical layers to take precedence over chit chat layers, for example.
/// </summary>
public class LayeredOrchestrationIntentResolver : OrchestrationIntentResolverBase
{
    /// <summary>
    /// Creates a new instance of the <see cref="LayeredOrchestrationIntentResolver"/> class.
    /// </summary>
    public LayeredOrchestrationIntentResolver()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="LayeredOrchestrationIntentResolver"/> class.
    /// </summary>
    /// <param name="layers">The starting layers</param>
    public LayeredOrchestrationIntentResolver(IEnumerable<OrchestrationLayer> layers) : base(layers)
    {
    }

    /// <summary>
    /// Finds a match for a given utterance.
    /// 
    /// Each intent resolver will be evaluated in sequence by its priority to see what it thinks about the utterance. If the intent resolver returns
    /// a match with a confidence score at or above its threshold, that match will be returned, otherwise the next IntentResolver is
    /// evaluated. If no IntentResolver returns a match above the threshold, the default intent is returned.
    /// </summary>
    /// <param name="utterance">The utterance to be evaluated</param>
    /// <returns>The matching LanguageResult or null if none matched.</returns>
    public override LanguageResult? FindIntent(string utterance)
    {
        foreach (OrchestrationLayer layer in Layers.OrderByDescending(l => l.Priority))
        {
            LanguageResult? intent = layer.IntentResolver.FindIntent(utterance);

            if (intent != null && intent.ConfidenceScore >= layer.MinConfidence)
            {
                intent.OrchestrationIntentName = layer.OrchestrationIntentName;

                return intent;
            }
        }

        return DefaultResult;
    }
}