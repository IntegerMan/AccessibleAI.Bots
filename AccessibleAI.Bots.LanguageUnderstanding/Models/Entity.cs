namespace AccessibleAI.Bots.LanguageUnderstanding.Models
{
    public class EntityMatch
    {
        public string Category { get; init; } = null!;
        public string Text { get; init; } = null!;
        public int Offset { get; init; }
        public int Length { get; init; }
        public double ConfidenceScore { get; init; }
        public string? ListKey { get; set; }
    }
}
