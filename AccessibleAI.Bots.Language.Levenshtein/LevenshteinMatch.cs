using AccessibleAI.Bots.Core.Language;
using System;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinMatch
{
    public LevenshteinMatch(LevenshteinEntry entry, int distance)
    {
        Entry = entry;
        Distance = distance;
    }

    public LevenshteinEntry Entry { get; }
    public int Distance { get; }

    public IntentMatch ToIntentMatch()
    {
        double confidence = (100 - Distance) / 100.0;

        return new()
        {
            OrchestrationName = Entry.OrchestrationName,
            Category = Entry.IntentName,
            MatchDetails = $"on '{Entry.Text}' with distance {Distance}",
            ConfidenceScore = Math.Max(0.0, confidence) // This will need some tweaking
        };
    }
}