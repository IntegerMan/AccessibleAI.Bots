﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class IamTiredIntent : ChitChatIntentBase
{
    public IamTiredIntent(string intentName = "IamTired") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Naps are nice.");
    }
}


