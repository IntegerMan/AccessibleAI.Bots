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

    [Fact]
    public void BotShouldRecognizeRegisteredDefaultIntents()
    {
        // Arrange
        TestBot bot = CreateBotWithChitChat();
        bot.AddDefaultIntents();
        TestTurnContext context = new("Hello there!");

        // Act
        IntentResolutionResult match = bot.MatchIntent(context);

        // Assert
        match.ShouldNotBeNull();
        match.IntentName.ShouldBe("Hello");
        match.OrchestrationIntentName.ShouldBe("ChitChat");
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
