using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatDoYouThinkOfMeIntent : ChitChatIntentBase
{
    public WhatDoYouThinkOfMeIntent(string intentName = "WhatDoYouThinkOfMeIntent") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I enjoy everyone I interact with.");
    }
}
