﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class ThatWasGoodIntent : ChitChatIntentBase
{
    public ThatWasGoodIntent(string intentName = "ThatWasGood") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Great!");
    }
}
