using System;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Language.Intents;

namespace AccessibleAI.Bots.Core;

public class ActionIntentHandler : IIntentHandler
{
    private readonly Func<ConversationContext, Task> handler;

    public ActionIntentHandler(Func<ConversationContext, Task> handler)
    {
        this.handler = handler;
    }

    public async Task ReplyAsync(ConversationContext context) => await handler(context);
}
