using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class ThatWasntFunnyIntent : ChitChatIntentBase
{
    public ThatWasntFunnyIntent(string intentName = "ThatWasntFunny") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry. I'm afraid I wasn't programmed with much of a sense of humor.");
    }
}
