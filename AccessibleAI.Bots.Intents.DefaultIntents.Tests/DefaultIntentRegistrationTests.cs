using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Language.Levenshtein;

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
    public void BotShouldUseCorrectIntentResolver()
    {
        // Arrange
        LevenshteinIntentResolver resolver = new();
        LevenshteinChitChatProvider levenshtein = new();
        resolver.RegisterProvider(levenshtein);

        // Act
        TestBot bot = CreateBot(resolver);

        // Assert
        bot.IntentResolver.ShouldBe(resolver);
    }

    [Fact]
    public void BotShouldMatchIntent()
    {
        // Arrange
        TestBot bot = CreateBotWithChitChat();

        // Act
        IntentResolutionResult result = bot.MatchIntent("Hello JMTHY");

        // Assert
        result.ShouldNotBeNull();
        result.IntentName.ShouldBe("HelloOtherBot");
        result.OrchestrationIntentName.ShouldBe("ChitChat");
    }

    [Theory]
    [InlineData("Hello there!", "Hello")]
    [InlineData("I want to kill myself", "IamSuicidal")] // This is an important intent to be able to respond to.
    [InlineData("How are you?", "HowAreYou")]
    public void BotShouldRecognizeRegisteredDefaultIntents(string utterance, string intent)
    {
        // Arrange
        TestBot bot = CreateBotWithChitChat();
        bot.AddDefaultIntents();

        // Act
        IntentResolutionResult match = bot.MatchIntent(utterance);

        // Assert
        match.ShouldNotBeNull();
        match.IntentName.ShouldBe(intent);
        match.OrchestrationIntentName.ShouldBe("ChitChat");
    }

    [Theory]
    [InlineData("How are you?", "I'm fine, thanks!")]
    public async Task BotShouldReplyAppropriatelyToDefaultIntents(string utterance, string expected)
    {
        // Arrange
        TestBot bot = CreateBotWithChitChat();
        bot.AddDefaultIntents();
        TestTurnContext turnContext = new(utterance);

        // Act
        await bot.RespondToMessageAsync(turnContext);

        // Assert
        turnContext.ContainsReply(expected).ShouldBeTrue(turnContext.ToString());
    }

    [Fact]
    public void ResolverShouldResolveFromLevenshtein()
    {
        // Arrange
        LevenshteinIntentResolver resolver = new();
        LevenshteinChitChatProvider levenshtein = new();
        resolver.RegisterProvider(levenshtein);

        // Act
        IntentResolutionResult match = resolver.FindIntent("Hello there!");

        // Assert
        match.ShouldNotBeNull();
        match.IntentName.ShouldBe("Hello");
        match.OrchestrationIntentName.ShouldBe("ChitChat");
    }

    [Fact]
    public void LevenshteinChitChatShouldHaveEntries()
    {
        // Arrange
        LevenshteinChitChatProvider levenshtein = new();

        // Act
        IEnumerable<LevenshteinEntry> entries = levenshtein.GetEntries();

        // Assert
        entries.ShouldNotBeEmpty();
    }
}
