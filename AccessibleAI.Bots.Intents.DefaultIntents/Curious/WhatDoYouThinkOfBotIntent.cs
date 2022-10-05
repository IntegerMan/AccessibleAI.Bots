namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatDoYouThinkOfBotIntent : ChitChatIntentBase
{
    public WhatDoYouThinkOfBotIntent(string intentName = "WhatDoYouThinkOfBot") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sure they're fantastic.");
    }
}
