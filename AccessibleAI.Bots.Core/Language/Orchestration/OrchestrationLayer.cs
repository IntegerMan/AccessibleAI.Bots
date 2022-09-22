using AccessibleAI.Bots.Core.Language;

namespace AccessibleAI.Bots.Core.Orchestration;

public class OrchestrationLayer
{
    public OrchestrationLayer(IIntentResolver intentResolver, string orchestrationIntentName, double priority = 1, double minConfidence = 0.8)
    {
        IntentResolver = intentResolver;
        OrchestrationIntentName = orchestrationIntentName;
        Priority = priority;
        MinConfidence = minConfidence;
    }

    public IIntentResolver IntentResolver { get; }
    public double MinConfidence { get; }
    public string OrchestrationIntentName { get; }
    public double Priority { get; }
}