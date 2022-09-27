namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class AmIABotTests
{
    [Fact]
    public async Task AmIABotShouldSayYes()
    {
        // Arrange
        AreYouABotIntent intent = new();
        TestConversationContext context = new();

        // Act
        await intent.ReplyAsync(context);

        // Assert
        context.Messages.ShouldContain(m => m.ToLowerInvariant().Contains("I'm a bot"));            
    }
}