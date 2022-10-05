namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

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
