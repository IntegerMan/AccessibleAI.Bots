using AccessibleAI.Bots.Core.Language;
using Quickenshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinIntentResolver : IIntentResolver
{
    // TODO: This is going to be too much to be in-memory at once. We'll need sources instead
    private List<ILevenshteinEntityProvider> _providers = new();

    public LevenshteinIntentResolver()
    {
        
    }

    public LevenshteinIntentResolver(ILevenshteinEntityProvider provider)
    {
        _providers.Add(provider);
    }

    public LevenshteinIntentResolver(IEnumerable<ILevenshteinEntityProvider> providers)
    {
        foreach (var provider in providers)
        {
            _providers.Add(provider);
        }
    }

    public bool CaseSensitive { get; set; }
    public bool IncludePunctuation { get; set; }

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
                    int distance = CalculateDistance(utterance, NormalizeString(entry.Text), normalize: false);

                    LevenshteinMatch match = entry.CreateMatch(distance);
                    matches[$"{match.Entry.OrchestrationName}/{match.Entry.IntentName}"] = match;
                }
            }

            // Grab the best match of each intent and add it to the result
            foreach (LevenshteinMatch match in matches.Values)
            {
                result.AddMatchingIntent(match.ToIntentMatch());
            }

            // Choose the best intent
            result.IntentName = result.Intents.OrderByDescending(i => i.ConfidenceScore).FirstOrDefault()?.Category ?? "None";
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

        return input;
    }

    public int CalculateDistance(string utterance, LevenshteinEntry entry, bool normalize = true)
    {
        return CalculateDistance(utterance, entry.Text, normalize);
    }

    public int CalculateDistance(string utterance, string target, bool normalize = true)
    {
        if (normalize)
        {
            target = NormalizeString(target);
            utterance = NormalizeString(utterance);
        }

        return Quickenshtein.Levenshtein.GetDistance(utterance, target);
    }
}