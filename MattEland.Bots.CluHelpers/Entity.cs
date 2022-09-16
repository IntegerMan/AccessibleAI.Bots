namespace AccessibleAI.Bots.CluHelpers
{
    public class EntityMatch
    {
        public string Category { get; set; }
        public string Text { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public double ConfidenceScore { get; set; }
        public string ListKey { get; set; }
    }
}
