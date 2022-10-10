using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public abstract class BotTestBase
{
    protected TestBot CreateBotWithChitChat()
    {
        LevenshteinChitChatProvider lev = new();
        LevenshteinIntentResolver resolver = new(provider: lev, minConfidence: 0.5);

        return CreateBot(resolver);
    }

    protected TestBot CreateBot(IIntentResolver? resolver = null) 
        => new TestBot(null, null, resolver ?? new TestIntentResolver());
}
