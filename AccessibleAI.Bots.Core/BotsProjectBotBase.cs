using System.Threading;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Intents;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Core;

public abstract class BotsProjectBotBase : ActivityHandler
{
    protected ConversationState ConversationState { get; }
    protected UserState UserState { get; }

    protected BotsProjectBotBase(ConversationState conversationState, UserState userState)
    {
        ConversationState = conversationState;
        UserState = userState;
    }

    public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
    {
        await base.OnTurnAsync(turnContext, cancellationToken);
        
        // Save any state changes that might have occurred during the turn.
        await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> context, CancellationToken token)
    {
        string replyText = $"No response programmed for '{context.Activity.Text}'";

        await context.ReplyAsync(replyText, token);
    }
}