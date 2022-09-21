using System.Collections.Generic;
using System.Linq;
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

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        foreach (var member in membersAdded)
        {
            // Greet anyone that was not the target (recipient) of this message.
            // To learn more about Adaptive Cards, see https://aka.ms/msbot-adaptivecards for more details.
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                await GreetUserAsync(turnContext, cancellationToken);
            }
        }
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> context, CancellationToken token)
    {
        LanguageResult? languageResult = IntentResolver.FindIntent(context.Activity.Text);

        if (languageResult == null)
        {
            PersonalityBase personality = InstantiatePersonality(context);
            await personality.HandleIntentAsync("None");
        }
        else
        {
            if (context.IsEmulator())
            {
                await DisplayIntentDebugInfoAsync(context, languageResult, token);
            }

            // Run the Dialog with the new message Activity.
            switch (languageResult.OrchestrationIntentName.ToUpperInvariant())
            {
                case "CHITCHAT":
                    await HandleChitChatIntentsAsync(context, languageResult, token);
                    break;

                default:
                    await HandleBotLogicIntentsAsync(context, languageResult, token);
                    break;
            }
        }
    }

    protected async Task HandleChitChatIntentsAsync(ITurnContext context, LanguageResult result, CancellationToken token)
    {
        PersonalityBase chitChat = InstantiatePersonality(context);
        await chitChat.HandleIntentAsync(result);
    }

    protected abstract Task HandleBotLogicIntentsAsync(ITurnContext context, LanguageResult result, CancellationToken token);


    protected abstract Task GreetUserAsync(ITurnContext<IConversationUpdateActivity> context, CancellationToken token);

    protected virtual async Task DisplayIntentDebugInfoAsync(ITurnContext context, LanguageResult languageResult, CancellationToken token)
    {
        await context.ReplyAsync($"Matched Intent: {languageResult} with confidence {languageResult.ConfidenceScore:P}", token);
    }

    protected virtual async Task DisplayIntentInfo(ITurnContext turnContext, LanguageResult result, CancellationToken token)
    {
        await turnContext.SendActivityAsync($"Matched intent: {result.TopIntent}", cancellationToken: token);
        await DisplayEntityInfo(turnContext, result, token);
    }

    protected virtual async Task DisplayEntityInfo(ITurnContext turnContext, LanguageResult result, CancellationToken token)
    {
        if (result.Entities.Any())
        {
            foreach (EntityMatch entity in result.Entities)
            {
                await turnContext.SendActivityAsync($"Found entity: {entity.Text} in category {entity.Category}", cancellationToken: token);
            }
        }
        else
        {
            await turnContext.SendActivityAsync("No entities found", cancellationToken: token);
            // await turnContext.SendActivityAsync(result.Json, cancellationToken: token);
        }
    }

    protected abstract PersonalityBase InstantiatePersonality(ITurnContext context);

    public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
    {
        await base.OnTurnAsync(turnContext, cancellationToken);
        
        // Save any state changes that might have occurred during the turn.
        await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
    }

}