namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class AskMeAQuestionTests
{
    [Fact]
    public async Task AskMeAQuestionShouldSayTheyCant()
    {
        // Arrange
        AskMeAQuestionIntent intent = new();
        TestConversationContext context = new();

        // Act
        await intent.ReplyAsync(context);

        // Assert
        context.ShouldContain("asking questions");            
    }
}