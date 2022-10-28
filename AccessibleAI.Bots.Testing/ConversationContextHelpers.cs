using AccessibleAI.Bots.Core;

namespace AccessibleAI.Bots.Testing;

public static class ConversationContextHelpers
{
    public static TestConversationContext ToTestConversationContext(this ConversationContext context)
    {
        TestConversationContext testContext = new(context.IntentResolution);

        return testContext;
    }
}
