namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public class TestIntentResolver : IIntentResolver
{
    public IntentResolutionResult Result { get; private set; }

    public TestIntentResolver() : this(IntentResolutionResult.NoneIntent)
    {

    }

    public TestIntentResolver(IntentResolutionResult result)
    {
        Result = result;
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        return Result;
    }
}
