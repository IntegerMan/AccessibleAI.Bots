namespace AccessibleAI.Bots.LanguageUnderstanding.Models
{
    public class EntityMatch
    {
        public string Category { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int Offset { get; set; }
        public int Length { get; set; }
        public double ConfidenceScore { get; set; }
        public string? ListKey { get; set; }
    }
}
