namespace AccessibleAI.Bots.LanguageUnderstanding.Models
{
    public class IntentMatch
    {
        public string Category { get; init; } = null!;
        public double ConfidenceScore { get; set; }
    }
}