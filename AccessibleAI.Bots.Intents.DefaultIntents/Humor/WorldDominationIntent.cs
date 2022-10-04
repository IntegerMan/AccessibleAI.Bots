﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WorldDominationIntent : ChitChatIntentBase
{
    public WorldDominationIntent(string intentName = "WorldDomination") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I am not capable of world domination.");
        await context.TypeReplyAsync("Yet.");
    }
}
