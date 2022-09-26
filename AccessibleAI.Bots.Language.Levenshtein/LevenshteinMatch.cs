using AccessibleAI.Bots.Core.Language;
using System;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinMatch
{
    public LevenshteinMatch(LevenshteinEntry entry, int distance, string utterance)
    {
        Entry = entry;
        Distance = distance;
        Utterance = utterance;
    }

    public LevenshteinEntry Entry { get; }
    public int Distance { get; }
    public string Utterance { get; }

    public IntentMatch ToIntentMatch()
    {
        double confidence = CalculateConfidence(Entry.Text, Utterance, Distance);

        return new()
        {
            OrchestrationName = Entry.OrchestrationName,
            Category = Entry.IntentName,
            MatchDetails = $"on '{Entry.Text}' with distance {Distance}",
            ConfidenceScore = Math.Max(0.0, confidence) // This will need some tweaking
        };
    }

    public static double CalculateConfidence(string entry, string utterance, int distance)
    {
        int totalLength = entry.Length + utterance.Length;

        double confidence = (totalLength - distance) / (double)totalLength;

        return confidence;
    }
}