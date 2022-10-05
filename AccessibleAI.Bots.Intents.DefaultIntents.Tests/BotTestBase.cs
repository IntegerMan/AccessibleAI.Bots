namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public abstract class BotTestBase
{
    protected TestBot CreateBot(IIntentResolver? resolver = null) 
        => new TestBot(null, null, resolver ?? new TestIntentResolver());
}
