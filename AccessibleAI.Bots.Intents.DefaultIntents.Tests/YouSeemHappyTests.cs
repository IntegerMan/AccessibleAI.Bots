using AccessibleAI.Bots.Intents.DefaultIntents.Social;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class YouSeemHappyTests
{
    [Fact]
    public async Task ExclamationTests()
    {
        // Arrange
        YouSeemHappyIntent intent = new();
        TestConversationContext context = new();

        // Act
        await intent.ReplyAsync(context);

        // Assert
        context.ShouldContain("!");            
    }
}