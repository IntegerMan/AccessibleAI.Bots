using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinTextFileEntityProvider : ILevenshteinEntityProvider
{
    public LevenshteinTextFileEntityProvider(string filePath)
    {
        FilePath = filePath;
    }

    public string[] Delimiters { get; set; } = new[] { "\t" };
    public string FilePath { get; }
    public bool HasHeaderRow { get; set; } = true;
    public string DefaultOrchestrationName { get; set; } = "None";
    public string DefaultIntentName { get; set; } = "None";

    public IEnumerable<LevenshteinEntry> GetEntries()
    {
        using (StreamReader streamReader = new(FilePath))
        {
            if (HasHeaderRow)
            {
                streamReader.ReadLine();
            }

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                string[] results = line.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                string text = results[0];
                string intentName = GetStringOrDefault(results, 1, DefaultIntentName);
                string orchestrationName = GetStringOrDefault(results, 2, DefaultOrchestrationName);

                yield return new LevenshteinEntry(text, intentName, orchestrationName);
            }
        }
    }

    private string GetStringOrDefault(string[] results, int index, string defaultValue) 
        => results.Length > index ? results[index] : defaultValue;
}
