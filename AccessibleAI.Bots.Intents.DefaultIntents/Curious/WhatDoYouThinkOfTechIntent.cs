using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatDoYouThinkOfTechIntent : ChitChatIntentBase
{
    public WhatDoYouThinkOfTechIntent(string intentName = "WhatDoYouThinkOfTech") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I wouldn't be here without technology.");
    }
}
