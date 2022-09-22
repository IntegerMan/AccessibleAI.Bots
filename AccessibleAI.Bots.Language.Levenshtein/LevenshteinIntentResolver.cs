using AccessibleAI.Bots.Core.Language;
using Quickenshtein;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinIntentResolver : IIntentResolver
{
    // TODO: This is going to be too much to be in-memory at once. We'll need sources instead
    private List<ILevenshteinEntityProvider> _providers = new();

    public void RegisterProvider(ILevenshteinEntityProvider provider)
    {
        _providers.Add(provider);
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        if (!_providers.Any()) throw new InvalidOperationException("Cannot find an intent without at least one registered entity provider");

        IntentResolutionResult result = new();

        // Someone may try to give it null or whitespace, so just return no matches for that
        if (!string.IsNullOrWhiteSpace(utterance))
        {
            List<LevenshteinMatch> matches = new();

            foreach (ILevenshteinEntityProvider provider in _providers)
            {
                foreach (LevenshteinEntry entry in provider.GetEntries())
                {
                    int distance = CalculateDistance(utterance, entry);

                    LevenshteinMatch match = entry.CreateMatch(distance);
                    matches.Add(match);

                    result.AddMatchingIntent(match.ToIntentMatch());
                }
            }

            result.IntentName = result.Intents.OrderByDescending(i => i.ConfidenceScore).FirstOrDefault()?.Category ?? "None";
        }

        return result;
    }

    public static int CalculateDistance(string utterance, LevenshteinEntry entry)
    {
        // Note: multi-threaded options exist for GetDistance and might be worth considering
        return Quickenshtein.Levenshtein.GetDistance(utterance, entry.Text);
    }
}