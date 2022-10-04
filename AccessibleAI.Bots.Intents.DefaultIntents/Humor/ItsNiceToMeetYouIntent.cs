﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class ItsNiceToMeetYouIntent : ChitChatIntentBase
{
    public ItsNiceToMeetYouIntent(string intentName = "ItsNiceToMeetYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("It's nice to meet you too!");
    }
}
