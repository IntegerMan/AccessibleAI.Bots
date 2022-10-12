namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class LevenshteinIntentMatchingTests
{
    [Theory]
    [InlineData("Hello there", "Hi")]
    [InlineData("Hello there World", "Hi")]
    [InlineData("Let's buy this car!", "BuyCar")]
    public void CorrectIntentShouldBeDetected(string utterance, string intent)
    {
        // Arrange      
        const string OrchestrationName = "Test";
        InMemoryLevenshteinEntityProvider provider = new(
            new LevenshteinEntry[] {
                new LevenshteinEntry("Hello", "Hi", OrchestrationName),
                new LevenshteinEntry("Hello World", "Hi", OrchestrationName),
                new LevenshteinEntry("Hi", "Hi", OrchestrationName),
                new LevenshteinEntry("Hail and well met", "Hi", OrchestrationName),
                new LevenshteinEntry("Goodbye", "Bye", OrchestrationName),
                new LevenshteinEntry("Later!", "Bye", OrchestrationName),
                new LevenshteinEntry("See you later!", "Bye", OrchestrationName),
                new LevenshteinEntry("Bye for now!", "Bye", OrchestrationName),
                new LevenshteinEntry("Goodbye my friend", "Bye", OrchestrationName),
                new LevenshteinEntry("I want to buy a car", "BuyCar", OrchestrationName),
                new LevenshteinEntry("Can I buy this car?", "BuyCar", OrchestrationName)
            });

        LevenshteinIntentResolver resolver = new()
        {
            MinimumConfidence = 0,
        };
        resolver.RegisterProvider(provider);

        // Act
        IntentResolutionResult result = resolver.FindIntent(utterance);

        // Assert
        result.IntentName.ShouldBe(intent, utterance);
        result.ConfidenceScore.ShouldBeGreaterThan(0.7, utterance);
        result.OrchestrationIntentName.ShouldBe(OrchestrationName);
    }

    [Fact]
    public void StringMatchingShouldParseCorrectly()
    {
        // Arrange
        string data = "Do you get hurt?\tBodyQuestion\r\nDo you have fingers?\tBodyQuestion\r\nDo you ever breathe\tBodyQuestion";
        LevenshteinStringBasedEntityProvider provider = new(data);

        // Act
        List<LevenshteinEntry> entries = provider.GetEntries().ToList();

        // Assert
        entries.Count.ShouldBe(3);
        entries.First().IntentName.ShouldBe("BodyQuestion");
        entries.First().Text.ShouldBe("Do you get hurt?");
    }
}