using System;
using System.Collections.Generic;
using System.IO;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinStringBasedEntityProvider : ILevenshteinEntityProvider
{
    public LevenshteinStringBasedEntityProvider(string data)
    {
        Data = data;
    }

    public string[] Delimiters { get; set; } = new[] { "/t" };
    public bool HasHeaderRow { get; set; } = true;
    public string DefaultOrchestrationName { get; set; } = "None";
    public string DefaultIntentName { get; set; } = "None";
    public string Data { get; }

    public IEnumerable<LevenshteinEntry> GetEntries()
    {
        using (StringReader reader = new(Data))
        {
            if (HasHeaderRow)
            {
                reader.ReadLine();
            }

            string line = reader.ReadLine();
            while (line != null)
            {

                string[] results = line.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                string text = results[0];
                string intentName = GetStringOrDefault(results, 1, DefaultIntentName);
                string orchestrationName = GetStringOrDefault(results, 2, DefaultOrchestrationName);

                yield return new LevenshteinEntry(text, intentName, orchestrationName);

                line = reader.ReadLine();
            }
        }
    }

    private string GetStringOrDefault(string[] results, int index, string defaultValue) 
        => results.Length > index ? results[index] : defaultValue;
}
