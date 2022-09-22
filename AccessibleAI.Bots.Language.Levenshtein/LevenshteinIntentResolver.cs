using AccessibleAI.Bots.Core.Language;
using Quickenshtein;
using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinIntentResolver : IIntentResolver
{
    // TODO: This is going to be too much to be in-memory at once. We'll need sources instead
    private List<LevenshteinEntry> _entries = new();

    public void AddEntry(LevenshteinEntry entry)
    {
        _entries.Add(entry);
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        List<LevenshteinMatch> matches = new();
        IntentResolutionResult result = new();

        foreach (LevenshteinEntry entry in _entries)
        {
            int distance = CalculateDistance(utterance, entry);

            LevenshteinMatch match = entry.CreateMatch(distance);
            matches.Add(match);

            result.AddMatchingIntent(match.ToIntentMatch());
        }

        result.IntentName = result.Intents.OrderByDescending(i => i.ConfidenceScore).FirstOrDefault()?.Category ?? "None";

        return result;
    }

    public static int CalculateDistance(string utterance, LevenshteinEntry entry)
    {
        // Note: multi-threaded options exist for GetDistance and might be worth considering
        return Quickenshtein.Levenshtein.GetDistance(utterance, entry.Text);
    }
}