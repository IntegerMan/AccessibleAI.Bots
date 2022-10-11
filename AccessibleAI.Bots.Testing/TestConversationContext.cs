using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Schema;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessibleAI.Bots.Testing;

public class TestConversationContext : ConversationContext
{
    public TestConversationContext(IntentResolutionResult? result = null)
        : base(new TestTurnContext(), default, result ?? new IntentResolutionResult())
    {
        TestContext = (TestTurnContext)TurnContext;
    }

    public void ShouldContain(string message)
    {
        StringBuilder sb = new();
        foreach (string m in Messages)
        {
            sb.AppendLine(m);
        }

        Messages.ShouldContain(m => m.Contains(message, StringComparison.InvariantCultureIgnoreCase), sb.ToString());
    }

    public TestTurnContext TestContext { get; }

    public IEnumerable<string> Messages => TestContext.Messages;
    public List<Activity> Activities => TestContext.Activities;
}