using System.Collections.Generic;
using AccessibleAI.Bots.LanguageUnderstanding.Models;

namespace AccessibleAI.Bots.LanguageUnderstanding.Orchestration;

public class LayeredOrchestrationIntentResolver : IIntentResolver
{
    private readonly List<OrchestrationLayer> _layers = new();

    public void AddLayer(OrchestrationLayer layer) => _layers.Add(layer);

    public LanguageResult? DefaultResult { get; set; }

    public LanguageResult? FindIntent(string utterance)
    {
        foreach (OrchestrationLayer layer in _layers)
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