namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

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
