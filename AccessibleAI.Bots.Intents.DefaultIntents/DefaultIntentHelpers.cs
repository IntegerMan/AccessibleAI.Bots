using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public static class DefaultIntentHelpers
{
    public static void AddDefaultIntents(this BotsProjectBotBase bot)
    {
        // Find all intents in this assembly that inherit from ChitChatIntentBase
        IEnumerable<Type> intents = typeof(DefaultIntentHelpers).Assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(ChitChatIntentBase)));

        // Register those types as intent handlers
        foreach (Type intentType in intents)
        {
            ChitChatIntentBase intent = (ChitChatIntentBase)Activator.CreateInstance(intentType)!;

            AddIntent(bot, intent);
        }
    }

    public static void AddIntent(this BotsProjectBotBase bot, IntentHandlerBase intent)
    {
        bot.RegisterIntentHandler(intent.Key, intent);
    }
}