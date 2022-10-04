using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WhatIsTheBestXIntent : ChitChatIntentBase
{
    public WhatIsTheBestXIntent(string intentName = "WhatIsTheBestX") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not programmed with many opinions.");
    }
}
