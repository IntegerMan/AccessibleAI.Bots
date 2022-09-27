namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class ConfidenceTests
{
    [Theory]
    [InlineData("Test", "Test", 1.0)]
    [InlineData("Tests", "Test", 0.95)]
    [InlineData("Test", "Tests", 0.95)]
    [InlineData("Test", "Tester", 0.8)]
    [InlineData("Tester", "Test", 0.8)]
    [InlineData("Zeus", "Posideon", 0.416)]
    public void CalculateConfidenceYieldsCorrectResult(string entry, string utterance, double expectedConfidence)
    {
        // Arrange
        int distance = LevenshteinIntentResolver.CalculateDistance(entry, utterance);

        // Act
        double confidence = LevenshteinMatch.CalculateConfidence(entry, utterance, distance);

        // Assert
        confidence.ShouldBe(expectedConfidence, 0.01, $"{utterance} -> {entry}");
    }
}