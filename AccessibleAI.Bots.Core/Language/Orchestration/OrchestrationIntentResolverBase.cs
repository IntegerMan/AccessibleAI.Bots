using System.Collections.Generic;
using AccessibleAI.Bots.Core.Language;

namespace AccessibleAI.Bots.Core.Orchestration;

public abstract class OrchestrationIntentResolverBase : IIntentResolver
{
    protected List<OrchestrationLayer> Layers { get; } = new();

    /// <summary>
    /// Creates a new instance of the <see cref="PooledOrchestrationIntentResolver"/> class.
    /// </summary>
    protected OrchestrationIntentResolverBase()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="PooledOrchestrationIntentResolver"/> class.
    /// </summary>
    /// <param name="layers">The starting layers</param>
    protected OrchestrationIntentResolverBase(IEnumerable<OrchestrationLayer> layers)
    {
        Layers.AddRange(layers);
    }

    /// <summary>
    /// Adds a layer to the orchestration intent resolver
    /// </summary>
    /// <param name="layer">The new layer</param>
    public void AddLayer(OrchestrationLayer layer) => Layers.Add(layer);

    /// <summary>
    /// Finds a match for a given utterance.
    /// 
    /// Each intent resolver will be evaluated in sequence by its priority to see what it thinks about the utterance. If the intent resolver returns
    /// a match with a confidence score at or above its threshold, that match will be returned, otherwise the next IntentResolver is
    /// evaluated. If no IntentResolver returns a match above the threshold, the default intent is returned.
    /// </summary>
    /// <param name="utterance">The utterance to be evaluated</param>
    /// <returns>The matching IntentResolutionResult or null if none matched.</returns>
    public abstract IntentResolutionResult FindIntent(string utterance);

}