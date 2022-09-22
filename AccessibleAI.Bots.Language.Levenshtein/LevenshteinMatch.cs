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
        => new()
        {
            OrchestrationName = Entry.OrchestrationName,
            Category = Entry.IntentName,
            ConfidenceScore = Math.Max(0.0, (100 - Distance) / 100.0) // This will need some tweaking
        };
}