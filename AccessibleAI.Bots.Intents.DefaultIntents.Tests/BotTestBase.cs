using AccessibleAI.Bots.Language.Levenshtein;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Tests;

public abstract class BotTestBase
{
    protected TestBot CreateBotWithChitChat()
    {
        ILevenshteinEntityProvider lev = new LevenshteinChitChatProvider();
        LevenshteinIntentResolver resolver = new(lev);

        TestBot bot = CreateBot(resolver);

        bot.AddDefaultIntents();

        return bot;
    }

    protected TestBot CreateBot(IIntentResolver? resolver = null) 
        => new TestBot(null, null, resolver ?? new TestIntentResolver());
}
