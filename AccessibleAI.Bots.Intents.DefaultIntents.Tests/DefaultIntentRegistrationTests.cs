namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class DefaultIntentRegistrationTests : BotTestBase
{
    [Fact]
    public void DefaultIntentRegistrationShouldRegisterIntents()
    {
        // Arrange
        TestBot bot = CreateBot();
        int startCount = bot.Intents.Count;

        // Act
        bot.AddDefaultIntents();

        // Assert
        bot.Intents.Count.ShouldBeGreaterThan(startCount + 80); // 87 pre-built intents
    }

    [Fact]
    public void BotShouldRecognizeRegisteredDefaultIntents()
    {
        // Arrange
        TestBot bot = CreateBot();
        bot.AddDefaultIntents();
        TestTurnContext context = new("Hello there!");

        // Act
        IntentResolutionResult match = bot.MatchIntent(context);

        // Assert
        match.ShouldNotBeNull();
        match.IntentName.ShouldBe("Hello");
        match.OrchestrationIntentName.ShouldBe("ChitChat");
    }
}
