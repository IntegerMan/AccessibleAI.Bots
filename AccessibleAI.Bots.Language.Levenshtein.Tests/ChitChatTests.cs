namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class ChitChatTests
{

    [Theory]
    [InlineData("Hello!", "Hello")]
    [InlineData("My name is Darth Vader", "None")]
    public void UtterancesShouldBeMappedToCorrectChitChat(string utterance, string expectedIntent)
    {
        // Arrange
        LevenshteinChitChatProvider chitChat = new();
        LevenshteinIntentResolver resolver = new(chitChat, 0.5);

        // Act
        IntentResolutionResult intent = resolver.FindIntent(utterance);

        // Assert
        intent.IntentName.ShouldBe(expectedIntent, customMessage: $"{intent.TopIntent?.ConfidenceScore ?? 0:P} - {intent.TopIntent?.MatchDetails}" ?? "No match details");
    }

}