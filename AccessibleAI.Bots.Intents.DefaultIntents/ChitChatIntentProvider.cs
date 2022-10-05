using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class ChitChatIntentResolver : LevenshteinTextFileEntityProvider
{
    public ChitChatIntentResolver(string filePath = "chitchat.tsv", string orchestrationName = "ChitChat") : base(filePath)
    {
        DefaultOrchestrationName = orchestrationName;
    }

}
