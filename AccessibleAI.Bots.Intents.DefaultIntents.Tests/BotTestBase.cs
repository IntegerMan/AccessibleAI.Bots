using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public abstract class BotTestBase
{
    protected TestBot CreateBotWithChitChat()
    {
        ILevenshteinEntityProvider lev = new LevenshteinChitChatProvider();
        LevenshteinIntentResolver resolver = new(lev);

        return CreateBot(resolver);
    }

    protected TestBot CreateBot(IIntentResolver? resolver = null) 
        => new TestBot(null, null, resolver ?? new TestIntentResolver());
}
