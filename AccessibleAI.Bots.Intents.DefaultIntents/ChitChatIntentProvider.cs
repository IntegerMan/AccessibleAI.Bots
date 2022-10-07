using AccessibleAI.Bots.Core.Language;
using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class ChitChatIntentProvider : LevenshteinTextFileEntityProvider, IIntentResolver
{
    public ChitChatIntentProvider(string filePath = "chitchat.tsv", string orchestrationName = "ChitChat") : base(filePath)
    {
        DefaultOrchestrationName = orchestrationName;
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        IntentResolutionResult result = new();

        foreach (LevenshteinEntry entry in this.GetEntries().OrderBy(e => e.I)
        {
            
        }

        return result;
    }
}
