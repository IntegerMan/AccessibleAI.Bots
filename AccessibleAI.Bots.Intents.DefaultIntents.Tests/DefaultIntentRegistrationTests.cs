using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Language.Intents;
using AccessibleAI.Bots.Intents.DefaultIntents.Curious;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class DefaultIntentRegistrationTests
{
    [Fact]
    public void DefaultIntentRegistrationShouldRegisterIntents()
    {
        // Arrange
        TestBot bot = new(default, default, default);
        int startCount = bot.Intents.Count;

        // Act
        bot.AddDefaultIntents();

        // Assert
        bot.Intents.Count.ShouldBeGreaterThan(startCount + 80); // 87 pre-built intents
    }
}

public class TestBot : BotsProjectBotBase
{
    public TestBot(ConversationState conversationState, UserState userState, IIntentResolver intentResolver) : base(conversationState, userState, intentResolver)
    {
    }

    public IReadOnlyList<IIntentHandler> Intents => IntentHandlers.Values.ToList();

    protected override Task GreetUserAsync(ConversationContext context)
    {
        return Task.CompletedTask;
    }
}