using System;

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

        public LevenshteinMatch CreateMatch(int distance, string utterance) 
            => new LevenshteinMatch(this, distance, utterance);

        public override bool Equals(object? obj)
        {
            return obj is LevenshteinEntry entry &&
                   Text == entry.Text &&
                   IntentName == entry.IntentName &&
                   OrchestrationName == entry.OrchestrationName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, IntentName, OrchestrationName);
        }

        public override string ToString()
        {
            return $"{OrchestrationName}/{IntentName}: {Text}";
        }
    }
}