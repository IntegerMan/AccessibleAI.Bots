using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class WhatDoYouDoIntent : ChitChatIntentBase
{
    public WhatDoYouDoIntent(string intentName = "WhatDoYouDo") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I respond to things you say that match things I know about.");
    }
}
