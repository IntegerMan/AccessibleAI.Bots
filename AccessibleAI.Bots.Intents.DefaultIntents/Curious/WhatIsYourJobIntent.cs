using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatIsYourJobIntent : ChitChatIntentBase
{
    public WhatIsYourJobIntent(string intentName = "WhatIsYourJob") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("My job is to talk to people like you!");
    }
}
