namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class LevenshteinDistanceCalculationTests
{
    [Theory]
    [InlineData("Hello World", "Hello World", 0)]
    [InlineData("Hi", "hi", 0)]
    [InlineData("Yo", "Yo!", 0)]
    [InlineData("Yo!", "YO", 0)]
    [InlineData("My name is Matt", "I would like to buy a pizza", 22)]
    public void StringsShouldHaveCorrectDistance(string utterance, string intent, int expected)
    {
        // Arrange
        LevenshteinEntry entry = new(intent, "Test", "Test");
        LevenshteinIntentResolver resolver = new();

        // Act
        int distance = resolver.CalculateDistance(utterance, entry);

        // Assert
        distance.ShouldBe(expected);
    }
}