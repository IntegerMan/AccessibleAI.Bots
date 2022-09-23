using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Intents;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Core;

public abstract class BotsProjectBotBase : ActivityHandler
{
    protected ConversationState ConversationState { get; }
    protected UserState UserState { get; }
    protected IIntentResolver IntentResolver { get; }

    protected BotsProjectBotBase(ConversationState conversationState, UserState userState, IIntentResolver intentResolver)
    {
        ConversationState = conversationState;
        UserState = userState;
        IntentResolver = intentResolver;
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
        IntentResolutionResult intentResult = IntentResolver.FindIntent(turnContext.Activity.Text);
        
        ConversationContext context = new(turnContext, token, intentResult);

        if (intentResult.TopIntent == null)
        {
            await HandleNoneIntentAsync(context);
        }
        else
        {
            if (context.IsEmulator)
            {
                await DisplayIntentDebugInfoAsync(context);
            }

            // Run the Dialog with the new message Activity.
            switch (intentResult.OrchestrationIntentName.ToUpperInvariant())
            {
                case "CHITCHAT":
                    await HandleChitChatIntentsAsync(context);
                    break;

                default:
                    await HandleBotLogicIntentsAsync(context);
                    break;
            }
        }
    }

    protected virtual async Task HandleNoneIntentAsync(ConversationContext context)
    {
        PersonalityBase personality = InstantiatePersonality(context);
        await personality.HandleIntentAsync(context, "None");
    }

    protected async Task HandleChitChatIntentsAsync(ConversationContext context)
    {
        PersonalityBase chitChat = InstantiatePersonality(context);
        await chitChat.HandleIntentAsync(context);
    }

    protected abstract Task HandleBotLogicIntentsAsync(ConversationContext context);

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

    protected abstract PersonalityBase InstantiatePersonality(ConversationContext context);

    public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
    {
        await base.OnTurnAsync(turnContext, cancellationToken);
        
        // Save any state changes that might have occurred during the turn.
        await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
    }

}