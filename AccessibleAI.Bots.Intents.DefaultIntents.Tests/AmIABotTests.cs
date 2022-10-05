using AccessibleAI.Bots.Intents.DefaultIntents.Curious;
using AccessibleAI.Bots.Testing;

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
        context.ShouldContain("I'm a Bot");            
    }
}
