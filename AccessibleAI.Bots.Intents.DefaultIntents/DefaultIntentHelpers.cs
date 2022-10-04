using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;
using AccessibleAI.Bots.Intents.DefaultIntents.Body;
using AccessibleAI.Bots.Intents.DefaultIntents.Humor;
using AccessibleAI.Bots.Intents.DefaultIntents.Social;
using AccessibleAI.Bots.Intents.DefaultIntents.Relationships;
using AccessibleAI.Bots.Intents.DefaultIntents.Curious;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public static class DefaultIntentHelpers
{
    public static void AddDefaultIntents(this BotsProjectBotBase bot)
    {
        AddIntent(bot, new AreYouABotIntent());
        AddIntent(bot, new AreYouInARelationshipIntent());
        AddIntent(bot, new AskMeAQuestionIntent());
        AddIntent(bot, new YouSeemHappyIntent());
        AddIntent(bot, new BeFriendsIntent());
    }

    public static void AddIntent(this BotsProjectBotBase bot, IntentHandlerBase intent)
    {
        bot.RegisterIntentHandler(intent.Key, intent);
    }
}