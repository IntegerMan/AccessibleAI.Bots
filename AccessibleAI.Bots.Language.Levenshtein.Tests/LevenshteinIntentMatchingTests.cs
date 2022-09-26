namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class LevenshteinIntentMatchingTests
{
    [Theory]
    [InlineData("Hello World", "Hi")]
    //[InlineData("Hey there World", "Hi")]
    [InlineData("Let's buy this car!", "BuyCar")]
    //[InlineData("So long!", "Bye")]
    public void CorrectIntentShouldBeDetected(string utterance, string intent)
    {
        // Arrange      
        InMemoryLevenshteinEntityProvider provider = new(
            new LevenshteinEntry[] {
                new LevenshteinEntry("Hello", "Hi", "Test"),
                new LevenshteinEntry("Hi", "Hi", "Test"),
                new LevenshteinEntry("Hail and well met", "Hi", "Test"),
                new LevenshteinEntry("Goodbye", "Bye", "Test"),
                new LevenshteinEntry("Later!", "Bye", "Test"),
                new LevenshteinEntry("See you later!", "Bye", "Test"),
                new LevenshteinEntry("Bye for now!", "Bye", "Test"),
                new LevenshteinEntry("Goodbye my friend", "Bye", "Test"),
                new LevenshteinEntry("I want to buy a car", "BuyCar", "Test") 
            });

        LevenshteinIntentResolver resolver = new();
        resolver.RegisterProvider(provider);

        // Ac
        IntentResolutionResult result = resolver.FindIntent(utterance);

        // Assert
        result.IntentName.ShouldBe(intent, utterance);
        result.ConfidenceScore.ShouldBeGreaterThan(0, utterance);
    }
}