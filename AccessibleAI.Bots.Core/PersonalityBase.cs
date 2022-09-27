using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Language.Intents;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Core;

public abstract class PersonalityBase
{
    protected PersonalityBase(ITurnContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Provides contextual information on the bot's current turn
    /// </summary>
    protected ITurnContext Context { get; }

    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public async Task HandleIntentAsync(ConversationContext context)
    {
        string intentName = context.IntentName;

        switch (intentName)
        {
            case "None":
                await RespondToRandomMessageAsync();
                break;
            case "ChitChat.HelloOtherBot":
                await RespondToHelloWrongNameAsync();
                break;
            case "ChitChat.HighFiveFistBump":
                await RespondToHighFiveFistBumpAsync();
                break;
            case "ChitChat.HowAreYou":
                await RespondToHowAreYouAsync();
                break;
            case "ChitChat.HowIsYourDayGoing":
                await RespondToHowIsYourDayAsync();
                break;
            case "ChitChat.HowOldAreYou":
                await RespondToHowOldAreYouAsync();
                break;
            case "ChitChat.IamAngry":
                await RespondToIamAngryAsync();
                break;
            case "ChitChat.IamBored":
                await RespondToIamBoredAsync();
                break;
            case "ChitChat.IamHappy":
                await RespondToIamHappyAsync();
                break;
            case "ChitChat.IamJoking":
                await RespondToIamJokingAsync();
                break;
            case "ChitChat.IamSad":
                await RespondToIamSadAsync();
                break;
            case "ChitChat.IamSuicidal":
                await RespondToIamSuicidalAsync();
                break;
            case "ChitChat.IamTired":
                await RespondToIamTiredAsync();
                break;
            case "ChitChat.IFeelAlone":
                await RespondToIFeelAloneAsync();
                break;
            case "ChitChat.ILikeYou":
                await RespondToILikeYouAsync();
                break;
            case "ChitChat.ILoveRandomThing":
                await RespondToILoveRandomThingAsync();
                break;
            case "ChitChat.ILoveYou":
                await RespondToILoveYouAsync();
                break;
            case "ChitChat.ImBack":
                await RespondToIHaveReturnedAsync();
                break;
            case "ChitChat.ImHungry":
                await RespondToIamHungryAsync();
                break;
            case "ChitChat.IMissedYou":
                await RespondToIMissedYouAsync();
                break;
            case "ChitChat.ImpossibleAction":
                await RespondToDoThisImpossibleThingAsync();
                break;
            case "ChitChat.ImSorry":
                await RespondToImSorryAsync();
                break;
            case "ChitChat.InformationAboutMeOrMyPlans":
                await RespondToRandomInformationAboutMeAsync();
                break;
            case "ChitChat.IsThisWorking":
                await RespondToIsThisWorkingAsync();
                break;
            case "ChitChat.ItsNiceToMeetYou":
                await RespondToNiceToMeetYouAsync();
                break;
            case "ChitChat.LetsMarry":
                await RespondToLetsMarryAsync();
                break;
            case "ChitChat.MiscPositive":
                await RespondToPositiveReactionAsync();
                break;
            case "ChitChat.PleaseSingToMe":
                await RespondToPleaseSingToMeAsync();
                break;
            case "ChitChat.PleaseWait":
                await RespondToPleaseWaitAsync();
                break;
            case "ChitChat.TellAJoke":
                await RespondToTellMeAJokeAsync();
                break;
            case "ChitChat.TellAnotherJoke":
                await RespondToTellMeAnotherJokeAsync();
                break;
            case "ChitChat.TellMeAboutMe":
                await RespondToTellMeAboutMeAsync();
                break;
            case "ChitChat.TellMeAboutYourFamily":
                await RespondToTellMeAboutYourFamilyAsync();
                break;
            case "ChitChat.ThankYou":
                await RespondToThankYouAsync();
                break;
            case "ChitChat.ThatsRepetitive":
                await RespondToThatIsRepetitiveAsync();
                break;
            case "ChitChat.ThatWasGood":
                await RespondToThatWasGoodAsync();
                break;
            case "ChitChat.ThatWasntFunny":
                await RespondToThatWasNotFunnyAsync();
                break;
            case "ChitChat.WhatDoYouDo":
                await RespondToWhatDoYouDoAsync();
                break;
            case "ChitChat.WhatDoYouThinkOfBot":
                await RespondToWhatDoYouThinkOfBotAsync();
                break;
            case "ChitChat.WhatDoYouThinkOfMe":
                await RespondToWhatDoYouThinkOfMeAsync();
                break;
            case "ChitChat.WhatDoYouThinkOfTech":
                await RespondToWhatDoYouThinkOfTechAsync();
                break;
            case "ChitChat.WhatIsTheBestX":
                await RespondToWhatIsTheBestXAsync();
                break;
            case "ChitChat.WhatIsTheMeaningOfLife":
                await RespondToWhatIsTheMeaningOfLifeAsync();
                break;
            case "ChitChat.WhatIsYourGender":
                await RespondToWhatIsYourGenderAsync();
                break;
            case "ChitChat.WhatIsYourJob":
                await RespondToWhatIsYourJobAsync();
                break;
            case "ChitChat.WhatIsYourName":
                await RespondToWhatIsYourNameAsync();
                break;
            case "ChitChat.WhatsNew":
                await RespondToWhatsNewAsync();
                break;
            case "ChitChat.WhereAreYou":
                await RespondToWhereAreYouAsync();
                break;
            case "ChitChat.WhoIsCuterYouOrMe":
                await RespondToWhoIsCuterYouOrMeAsync();
                break;
            case "ChitChat.WhoIsSmarterYouOrMe":
                await RespondToWhoIsSmarterYouOrMeAsync();
                break;
            case "ChitChat.WhoIsYourBoss":
                await RespondToWhoIsYourBossAsync();
                break;
            case "ChitChat.WhoMadeYou":
                await RespondToWhoMadeYouAsync();
                break;
            case "ChitChat.Whoops":
                await RespondToMyBadAsync();
                break;
            case "ChitChat.WorldDomination":
                await RespondToAreYouPlanningWorldDominationAsync();
                break;
            case "ChitChat.YouAreFunny":
                await RespondToYouAreFunnyAsync();
                break;
            case "ChitChat.YouAreRight":
                await RespondToYouAreRightAsync();
                break;
            case "ChitChat.YouAreSmart":
                await RespondToYouAreSmartAsync();
                break;
            case "ChitChat.YouAreStupid":
                await RespondToYouAreStupidAsync();
                break;
            case "ChitChat.YouAreUgly":
                await RespondToYouAreUglyAsync();
                break;
            case "ChitChat.YouHateMe":
                await RespondToYouHateMeAsync();
                break;
            case "ChitChat.YoureFired":
                await RespondToYouAreFiredAsync();
                break;
            case "ChitChat.YoureNotHelpful":
                await RespondToYouAreNotHelpfulAsync();
                break;
            case "ChitChat.YoureNotMakingSense":
                await RespondToYouAreNotMakingSenseAsync();
                break;
            case "ChitChat.YoureWelcome":
                await RespondToYouAreWelcomeAsync();
                break;
            default:
                await RespondToUnmappedIntentAsync(context);
                break;
        }
    }

    public virtual async Task RespondToUnmappedIntentAsync(ConversationContext context)
    {
        await ReplyAsync($"Uh oh! I should have been able to respond to the {context.MatchedIntent?.ToString() ?? "Empty"} intent, but I don't know how to yet.");
    }

    public abstract Task RespondToRandomMessageAsync();

    protected async Task ReplyAsync(string message)
    {
        await Context.SendActivityAsync(message);
    }

}