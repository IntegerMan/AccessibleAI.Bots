namespace AccessibleAI.Bots.Core.Language;

public class IntentMatch
{
    public IntentMatch()
    {

    }

    public IntentMatch(string category, string? orchestrationName = null, double confidenceScore = 0)
    {
        Category = category;
        OrchestrationName = orchestrationName;
        ConfidenceScore = confidenceScore;
    }

    public string? OrchestrationName { get; set; }
    public string Category { get; set; } = null!;
    public double ConfidenceScore { get; set; }

    public string? MatchDetails { get; set; }

    public override string ToString()
    {
        string match = string.IsNullOrWhiteSpace(MatchDetails)
            ? ""
            : $" {MatchDetails}";

        return !string.IsNullOrWhiteSpace(OrchestrationName)
            ? $"{OrchestrationName}/{Category} ({ConfidenceScore:P}){match}"
            : $"{Category} ({ConfidenceScore:P}){match}";
    }
}