using AccessibleAI.Bots.Language.Levenshtein;
using System.IO;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class LevenshteinChitChatProvider : AggregateLevenshteinEntityProvider
{
    public LevenshteinChitChatProvider(string orchestrationName = "ChitChat")
    {
        Stream resource = GetType().Assembly.GetManifestResourceStream("AccessibleAI.Bots.Intents.DefaultIntents.chitchat.tsv");
        using (StreamReader reader = new(resource))
        {
            string text = reader.ReadToEnd();

            LevenshteinStringBasedEntityProvider provider = new(text)
            {
                DefaultOrchestrationName = orchestrationName
            };

            List<LevenshteinEntry> entities = provider.GetEntries().ToList();

            Add(provider);
        }
    }
}
