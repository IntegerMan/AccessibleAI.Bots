using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Intents;
using AccessibleAI.Bots.Core.Language;
using AccessibleAI.Bots.Core.Language.Intents;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Core;

public abstract class BotsProjectBotBase : ActivityHandler
{
    public const string NoneIntentKey = "NONE/NONE";

    protected Dictionary<string, IIntentHandler> IntentHandlers { get; } = new();

    protected ConversationState ConversationState { get; }
    protected UserState UserState { get; }
    protected IIntentResolver IntentResolver { get; }

    protected BotsProjectBotBase(ConversationState conversationState, UserState userState, IIntentResolver intentResolver)
    {
        ConversationState = conversationState;
        UserState = userState;
        IntentResolver = intentResolver ?? throw new ArgumentNullException(nameof(intentResolver));

        // Ensure we can handle the None intent by calling the virtual method
        IntentHandlers[NoneIntentKey] = new ActionIntentHandler(HandleNoneIntentAsync);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded,
        ITurnContext<IConversationUpdateActivity> turnContext,
        CancellationToken cancellationToken)
    {
        // Greet anyone that was not the target (recipient) of this message.
        foreach (ChannelAccount _ in membersAdded.Where(m => m.Id != turnContext.Activity.Recipient.Id))
        {
            ConversationContext context = new(turnContext, cancellationToken, new IntentResolutionResult());

            await GreetUserAsync(context);
        }
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken token)
    {
        IntentResolutionResult intentResult = MatchIntent(turnContext);

        ConversationContext context = new(turnContext, token, intentResult);

        if (context.IsEmulator)
        {
            await DisplayIntentDebugInfoAsync(context);
        }

        string key = intentResult.IntentKey.ToUpperInvariant();
        if (IntentHandlers.ContainsKey(key))
        {
            await IntentHandlers[key].ReplyAsync(context);
        }
        else
        {
            if (context.IsEmulator)
            {
                await context.ErrorReplyAsync($"No intent handler registered for {key}");
            }

            await HandleNoneIntentAsync(context);
        }
    }

    public virtual IntentResolutionResult MatchIntent(ITurnContext turnContext) 
        => IntentResolver.FindIntent(turnContext.Activity.Text);

    protected virtual async Task HandleNoneIntentAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, I don't understand.");
    }

    protected abstract Task GreetUserAsync(ConversationContext context);

    protected virtual async Task DisplayIntentDebugInfoAsync(ConversationContext context)
    {
        IntentResolutionResult result = context.IntentResolution;

        // Always include the top intent
        StringBuilder sb = new();

        // List other relevant intents
        if (result.Intents.Any(i => i != result.TopIntent))
        {
            sb.AppendLine();
            sb.AppendLine("Other Considered Intents:");

            const int maxOtherIntents = 5;
            result.Intents.Where(i => i != result.TopIntent).Take(maxOtherIntents).ToList().ForEach(i =>
            {
                sb.AppendLine($"- {i}");
                if (!string.IsNullOrWhiteSpace(i.MatchDetails))
                {
                    sb.AppendLine($"    - {i}");
                }
            });
        }

        // Display Entity information
        if (result.Entities.Any())
        {
            sb.AppendLine();
            sb.AppendLine("Entities:");

            result.Entities.ToList().ForEach(e => sb.AppendLine($"- {e}"));
        }

        CardInformation info = new($"Matched Intent: {result}", sb.ToString(), null);
        await context.SendHeroAsync(info);
    }

    public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
    {
        await base.OnTurnAsync(turnContext, cancellationToken);

        // Save any state changes that might have occurred during the turn.
        await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
    }

    public void RegisterNoneIntentHandler(IIntentHandler handler) => RegisterIntentHandler(NoneIntentKey, handler);

    public void RegisterIntentHandler(string key, IIntentHandler intentHandler)
    {
        // Parameter Validation
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
        }
        if (intentHandler is null)
        {
            throw new ArgumentNullException(nameof(intentHandler));
        }

        // Add or update the handler
        IntentHandlers[key.ToUpperInvariant()] = intentHandler;
    }

    public void RegisterIntentHandler(string key, string response) 
        => RegisterIntentHandler(key, new SimpleIntentHandler(key, response));
}