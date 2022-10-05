using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class ChitChatIntentResolver : LevenshteinTextFileEntityProvider
{
    public ChitChatIntentResolver(string filePath = "chitchat.tsv") : base(filePath)
    {
    }

}
