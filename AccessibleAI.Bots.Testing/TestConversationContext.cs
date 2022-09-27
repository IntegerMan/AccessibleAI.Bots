using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Testing;

public class TestConversationContext : ConversationContext
{
    public TestConversationContext(IntentResolutionResult? result = null)
        : base(new TestTurnContext(), default, result ?? new IntentResolutionResult())
    {
        TestContext = (TestTurnContext)TurnContext;
    }

    public TestTurnContext TestContext { get; }

    public IEnumerable<string> Messages => TestContext.Messages;
    public List<Activity> Activities => TestContext.Activities;
}