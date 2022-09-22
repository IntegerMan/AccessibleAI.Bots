namespace AccessibleAI.Bots.Core.Language;

public class IntentMatch
{
    public string? OrchestrationName { get; set; }
    public string Category { get; set; } = null!;
    public double ConfidenceScore { get; set; }

    public override string ToString() =>
        !string.IsNullOrWhiteSpace(OrchestrationName)
            ? $"{OrchestrationName}/{Category} ({ConfidenceScore:P})" 
            : $"{Category} ({ConfidenceScore:P})";
}