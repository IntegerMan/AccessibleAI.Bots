using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public static class DefaultIntentHelpers
{
    public static void AddDefaultIntents(this BotsProjectBotBase bot)
    {
        AddIntent(bot, new AreYouABotIntent());
    }

    public static void AddIntent(this BotsProjectBotBase bot, IntentHandlerBase intent)
    {
        bot.RegisterIntentHandler(intent.Key, intent);
    }
}