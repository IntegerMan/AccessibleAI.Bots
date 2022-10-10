using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Language.Intents;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class TestBot : BotsProjectBotBase
{
    public TestBot(ConversationState? conversationState, UserState? userState, IIntentResolver intentResolver) : base(conversationState!, userState!, intentResolver)
    {
    }

    public IReadOnlyList<IIntentHandler> Intents => IntentHandlers.Values.ToList();

    protected override Task GreetUserAsync(ConversationContext context)
    {
        return Task.CompletedTask;
    }
}