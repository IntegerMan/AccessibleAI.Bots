using AccessibleAI.Bots.Core.Language;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Entity = Entry.Entity,
            MatchDetails = $"on '{Entry.Text}' with distance {Distance}",
            ConfidenceScore = Math.Max(0.0, confidence) // This will need some tweaking
        };
    }

    public static double CalculateConfidence(string entry, string utterance, int distance)
    {
        // For perfect matches, go with 100%
        if (distance <= 0)
        {
            return 1;
        }

        // Always count 1 off as 95%
        if (distance == 1)
        {
            return 0.95;
        }

        // Calculate a raw percentage
        int totalLength = entry.Length + utterance.Length;
        double confidence = (totalLength - distance) / (double)totalLength;

        IEnumerable<string> utteranceWords = utterance.Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).Distinct();
        IEnumerable<string> entryWords = utterance.Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).Distinct();

        foreach (var word in entryWords.Where(w => utteranceWords.Contains(w)))
        {
            confidence += 0.1 * (1.0/entryWords.Count());
        }

        return Math.Max(0, Math.Min(0.98, confidence));
    }
}