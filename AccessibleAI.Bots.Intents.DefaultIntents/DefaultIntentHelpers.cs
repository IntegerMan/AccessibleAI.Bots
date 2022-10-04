using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;
using System.Globalization;
using System.Reflection;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public static class DefaultIntentHelpers
{
    public static void AddDefaultIntents(this BotsProjectBotBase bot)
    {
        // Find all intents in this assembly that inherit from ChitChatIntentBase
        IEnumerable<Type> intents = typeof(DefaultIntentHelpers).Assembly.GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(ChitChatIntentBase)));

        // Register those types as intent handlers
        foreach (Type intentType in intents)
        {
            // These classes have a constructor that takes in a single parameter with a default value. Turns out Activator doesn't like that, so we need to specify extra junk
            ChitChatIntentBase intent = (ChitChatIntentBase)Activator.CreateInstance(intentType,
                    bindingAttr: BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance | BindingFlags.OptionalParamBinding,
                    binder: null,
                    args: new object[] { Type.Missing },
                    culture: CultureInfo.CurrentCulture)!;

            AddIntent(bot, intent);
        }
    }

    public static void AddIntent(this BotsProjectBotBase bot, IntentHandlerBase intent)
    {
        bot.RegisterIntentHandler(intent.Key, intent);
    }
}