using AccessibleAI.Bots.Core.Language;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinIntentResolver : IIntentResolver
{
    // TODO: This is going to be too much to be in-memory at once. We'll need sources instead
    private List<ILevenshteinEntityProvider> _providers = new();

    public LevenshteinIntentResolver(double minConfidence = 0.5)
    {
        MinConfidence = minConfidence;
    }

    public LevenshteinIntentResolver(ILevenshteinEntityProvider provider, double minConfidence = 0.5)
    {
        _providers.Add(provider);

        MinConfidence = minConfidence;
    }

    public LevenshteinIntentResolver(IEnumerable<ILevenshteinEntityProvider> providers, double minConfidence = 0.5)
    {
        foreach (ILevenshteinEntityProvider provider in providers)
        {
            _providers.Add(provider);
        }

        MinConfidence = minConfidence;
    }

    public double MinimumConfidence { get; set; } = 0.5;

    public bool CaseSensitive { get; set; }
    public bool IncludePunctuation { get; set; }
    public double MinConfidence { get; }

    public void RegisterProvider(ILevenshteinEntityProvider provider)
    {
        _providers.Add(provider);
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        if (!_providers.Any()) throw new InvalidOperationException("Cannot find an intent without at least one registered entity provider");

        IntentResolutionResult result = new();

        utterance = NormalizeString(utterance);

        // Someone may try to give it null or whitespace, so just return no matches for that
        if (!string.IsNullOrWhiteSpace(utterance))
        {
            // Track the best matches for each intent name
            Dictionary<string, LevenshteinMatch> matches = new();

            foreach (ILevenshteinEntityProvider provider in _providers)
            {
                foreach (LevenshteinEntry entry in provider.GetEntries())
                {
                    int distance = CalculateDistance(utterance, NormalizeString(entry.Text));

                    LevenshteinMatch match = entry.CreateMatch(distance, utterance);

                    string key = $"{match.Entry.OrchestrationName}/{match.Entry.IntentName}";

                    if (matches.ContainsKey(key))
                    {
                        // If we already have the intent and our distance is less, use this distance instead
                        if (matches[key].Distance > match.Distance)
                        {
                            matches[key] = match;
                        }
                    }
                    else
                    {
                        // New intent, just accept it
                        matches[key] = match;
                    }
                }
            }

            // Grab the best match of each intent and add it to the result
            foreach (LevenshteinMatch match in matches.Values)
            {
                IntentMatch intentMatch = match.ToIntentMatch();

                // Do not include low confidence results
                if (intentMatch.ConfidenceScore >= MinimumConfidence)
                {
                    result.AddMatchingIntent(intentMatch);
                }
            }

            // Choose the best intent
            IntentMatch bestMatch = result.Intents.OrderByDescending(i => i.ConfidenceScore).FirstOrDefault();
            result.IntentName = bestMatch?.Category ?? "None";
            result.OrchestrationIntentName = bestMatch?.OrchestrationName ?? "None";
        }

        return result;
    }

    private string NormalizeString(string input)
    {
        if (!CaseSensitive)
        {
            input = input.ToLowerInvariant();
        }

        if (!IncludePunctuation)
        {
            
            input = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
        }

        return input.Trim();
    }

    public int CalculateDistance(string utterance, LevenshteinEntry entry, bool normalize = true)
    {
        string target = entry.Text;

        if (normalize)
        {
            target = NormalizeString(target);
            utterance = NormalizeString(utterance);
        }

        return CalculateDistance(utterance, target);
    }

    public static int CalculateDistance(string utterance, string target) 
        => Quickenshtein.Levenshtein.GetDistance(utterance, target);
}