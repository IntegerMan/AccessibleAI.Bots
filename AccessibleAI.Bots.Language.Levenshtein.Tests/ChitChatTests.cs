namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class ChitChatTests
{

    [Theory]
    [InlineData("Hello!", "Hello")]
    [InlineData("I would like to buy a Winnebago", "None")]
    public void UtterancesShouldBeMappedToCorrectChitChat(string utterance, string expectedIntent)
    {
        // Arrange
        LevenshteinChitChatProvider chitChat = new();
        LevenshteinIntentResolver resolver = new(chitChat);

        // Act
        IntentResolutionResult intent = resolver.FindIntent(utterance);

        // Assert
        intent.IntentName.ShouldBe(expectedIntent, customMessage: $"{intent.TopIntent?.ConfidenceScore ?? 0:P} - {intent.TopIntent?.MatchDetails}" ?? "No match details");
    }

}
