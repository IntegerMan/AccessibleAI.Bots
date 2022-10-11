namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class AreYouInARelationshipTests
{
    [Fact]
    public async Task AmIABotShouldSayYes()
    {
        // Arrange
        AreYouInARelationshipIntent intent = new();
        TestConversationContext context = new();

        // Act
        await intent.ReplyAsync(context);

        // Assert
        context.ShouldContain("not willing");
    }
}