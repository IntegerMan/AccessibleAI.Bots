namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinChitChatProvider : LevenshteinTextFileEntityProvider
{
    public LevenshteinChitChatProvider(string orchestrationName = "ChitChat") : base("chitchat.tsv")
    {
        this.DefaultOrchestrationName = orchestrationName;
    }
}
