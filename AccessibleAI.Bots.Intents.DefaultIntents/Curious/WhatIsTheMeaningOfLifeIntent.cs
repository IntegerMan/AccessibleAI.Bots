namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatIsTheMeaningOfLifeIntent : ChitChatIntentBase
{
    public WhatIsTheMeaningOfLifeIntent(string intentName = "WhatIsTheMeaningOfLife") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I've been told the answer to this question is '42', but that doesn't sound right.");
    }
}
