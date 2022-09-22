namespace AccessibleAI.Bots.Language.Levenshtein
{
    public class LevenshteinEntry
    {
        public LevenshteinEntry(string text, string intentName, string orchestrationName)
        {
            Text = text;
            IntentName = intentName;
            OrchestrationName = orchestrationName;
        }

        public string Text { get; }
        public string IntentName { get; }
        public string OrchestrationName { get; }

        public LevenshteinMatch CreateMatch(int distance) => new LevenshteinMatch(this, distance);
    }
}