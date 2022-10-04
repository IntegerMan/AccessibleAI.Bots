using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatIsYourNameIntent : ChitChatIntentBase
{
    public WhatIsYourNameIntent(string intentName = "WhatIsYourName") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("You know, it's funny, but I actually don't know my name.");
    }
}
