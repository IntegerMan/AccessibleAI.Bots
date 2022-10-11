namespace AccessibleAI.Bots.Language.Levenshtein;

public class LevenshteinChitChatProvider : AggregateLevenshteinEntityProvider
{
    public LevenshteinChitChatProvider(string orchestrationName = "ChitChat")
    {
        this.Add(new LevenshteinTextFileEntityProvider("chitchat.tsv") { DefaultOrchestrationName = orchestrationName });
    }
}
