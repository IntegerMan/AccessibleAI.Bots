using AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class BeFriendsTests
{
    [Fact]
    public async Task BeFriendsShouldSayOfCourse()
    {
        // Arrange
        BeFriendsIntent intent = new();
        TestConversationContext context = new();

        // Act
        await intent.ReplyAsync(context);

        // Assert
        context.ShouldContain("happy to be your friend");
    }
}