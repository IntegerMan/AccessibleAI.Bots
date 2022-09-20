using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.LanguageUnderstanding.ChitChat;

public abstract class ChitChatHandlerBase : IIntentHandler
{
    protected ChitChatHandlerBase(ITurnContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Provides contextual information on the bot's current turn
    /// </summary>
    protected ITurnContext Context { get; }

    public async Task HandleIntentAsync(LanguageResult languageResult) 
        => await HandleIntentAsync(languageResult.IntentName);

    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public async Task HandleIntentAsync(string intent)
    {
        switch (intent)
        {
            case "None":
                await RespondToRandomMessageAsync();
                break;
            case "ChitChat.AreYouABot":
                await RespondToAreYouABotAsync();
                break;
            case "ChitChat.AreYouInARelationship":
                await RespondToAreYouInARelationshipAsync();
                break;
            case "ChitChat.AskMeAQuestion":
                await RespondToAskMeAQuestionAsync();
                break;
            case "ChitChat.BeFriends":
                await RespondToBeFriendsAsync();
                break;
            case "ChitChat.BeFunny":
                await RespondToBeFunnyAsync();
                break;
            case "ChitChat.BeQuiet":
                await RespondToBeQuietAsync();
                break;
            case "ChitChat.BodyQuestion":
                await RespondToBodyQuestionAsync();
                break;
            case "ChitChat.Boring":
                await RespondToYouAreBoringAsync();
                break;
            case "ChitChat.CanYouChatWithMe":
                await RespondToCanYouChatWithMeAsync();
                break;
            case "ChitChat.CanYouClarifyThat":
                await RespondToCanYouClarifyThatAsync();
                break;
            case "ChitChat.CanYouHugMe":
                await RespondToCanYouHugMeAsync();
                break;
            case "ChitChat.CanYouLoveMe":
                await RespondToCanYouLoveAsync();
                break;
            case "ChitChat.DoILookNice":
                await RespondToDoILookNiceAsync();
                break;
            case "ChitChat.DoYouEat":
                await RespondToDoYouEatAsync();
                break;
            case "ChitChat.DoYouLikeMe":
                await RespondToDoYouLikeMeAsync();
                break;
            case "ChitChat.DoYouLikeRandomThing":
                await RespondToDoYouLikeRandomThingAsync();
                break;
            case "ChitChat.DoYouLove":
                await RespondToDoYouLoveAsync();
                break;
            case "ChitChat.Goodbye":
                await RespondToGoodbyeAsync();
                break;
            case "ChitChat.GoodEvening":
                await RespondToGoodEveningAsync();
                break;
            case "ChitChat.GoodMorning":
                await RespondToGoodMorningAsync();
                break;
            case "ChitChat.GoodNight":
                await RespondToGoodNightAsync();
                break;
            case "ChitChat.HappyHoliday":
                await RespondToHappyHolidayAsync();
                break;
            case "ChitChat.HaveYouMetBot":
                await RespondToHaveYouMetBotAsync();
                break;
            case "ChitChat.Hello":
                await RespondToHelloAsync();
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
            case "ChitChat.YouSeemHappy":
                await RespondToYouSeemHappyAsync();
                break;
            default:
                await RespondToUnmappedIntentAsync(intent);
                break;
        }
    }

    public virtual async Task RespondToUnmappedIntentAsync(string intent)
    {
        await ReplyAsync($"Uh oh! I should have been able to respond to the {intent} intent, but I don't know how to yet.");
    }

    public abstract Task RespondToAreYouInARelationshipAsync();
    public abstract Task RespondToAreYouABotAsync();
    public abstract Task RespondToRandomMessageAsync();
    public abstract Task RespondToYouSeemHappyAsync();
    public abstract Task RespondToAskMeAQuestionAsync();
    public abstract Task RespondToBeFriendsAsync();
    public abstract Task RespondToBeQuietAsync();
    public abstract Task RespondToBeFunnyAsync();
    public abstract Task RespondToBodyQuestionAsync();
    public abstract Task RespondToYouAreBoringAsync();
    public abstract Task RespondToCanYouChatWithMeAsync();
    public abstract Task RespondToCanYouClarifyThatAsync();
    public abstract Task RespondToCanYouHugMeAsync();
    public abstract Task RespondToCanYouLoveAsync();
    public abstract Task RespondToDoILookNiceAsync();
    public abstract Task RespondToDoYouEatAsync();
    public abstract Task RespondToDoYouLikeMeAsync();
    public abstract Task RespondToDoYouLikeRandomThingAsync();
    public abstract Task RespondToDoYouLoveAsync();
    public abstract Task RespondToGoodbyeAsync();
    public abstract Task RespondToGoodEveningAsync();
    public abstract Task RespondToGoodMorningAsync();
    public abstract Task RespondToGoodNightAsync();
    public abstract Task RespondToHappyHolidayAsync();
    public abstract Task RespondToHelloAsync();
    public abstract Task RespondToHelloWrongNameAsync();
    public abstract Task RespondToHighFiveFistBumpAsync();
    public abstract Task RespondToHaveYouMetBotAsync();
    public abstract Task RespondToHowAreYouAsync();
    public abstract Task RespondToHowIsYourDayAsync();
    public abstract Task RespondToHowOldAreYouAsync();
    public abstract Task RespondToIamAngryAsync();
    public abstract Task RespondToIamHungryAsync();
    public abstract Task RespondToIamBoredAsync();
    public abstract Task RespondToIamHappyAsync();
    public abstract Task RespondToIamJokingAsync();
    public abstract Task RespondToIamSadAsync();

    public virtual async Task RespondToIamSuicidalAsync()
    {
        await ReplyAsync("The National Suicide Prevention Lifeline is available 24/7. You can call 1-800-273-8255 or visit [www.suicidepreventionlifeline.org](www.suicidepreventionlifeline.org).");
    }
    public abstract Task RespondToIamTiredAsync();
    public abstract Task RespondToIFeelAloneAsync();
    public abstract Task RespondToILikeYouAsync();
    public abstract Task RespondToILoveYouAsync();
    public abstract Task RespondToILoveRandomThingAsync();
    public abstract Task RespondToIHaveReturnedAsync();
    public abstract Task RespondToIMissedYouAsync();
    public abstract Task RespondToDoThisImpossibleThingAsync();
    public abstract Task RespondToImSorryAsync();
    public abstract Task RespondToIsThisWorkingAsync();
    public abstract Task RespondToRandomInformationAboutMeAsync();
    public abstract Task RespondToNiceToMeetYouAsync();
    public abstract Task RespondToLetsMarryAsync();
    public abstract Task RespondToPositiveReactionAsync();
    public abstract Task RespondToPleaseSingToMeAsync();
    public abstract Task RespondToPleaseWaitAsync();
    public abstract Task RespondToTellMeAJokeAsync();
    public abstract Task RespondToTellMeAnotherJokeAsync();
    public abstract Task RespondToTellMeAboutMeAsync();
    public abstract Task RespondToTellMeAboutYourFamilyAsync();
    public abstract Task RespondToThankYouAsync();
    public abstract Task RespondToThatIsRepetitiveAsync();
    public abstract Task RespondToThatWasGoodAsync();
    public abstract Task RespondToThatWasNotFunnyAsync();
    public abstract Task RespondToWhatDoYouDoAsync();
    public abstract Task RespondToWhatDoYouThinkOfMeAsync();
    public abstract Task RespondToWhatDoYouThinkOfBotAsync();
    public abstract Task RespondToWhatDoYouThinkOfTechAsync();
    public abstract Task RespondToWhatIsTheBestXAsync();
    public abstract Task RespondToWhatIsTheMeaningOfLifeAsync();
    public abstract Task RespondToWhatIsYourGenderAsync();
    public abstract Task RespondToWhatIsYourJobAsync();
    public abstract Task RespondToWhatsNewAsync();
    public abstract Task RespondToWhereAreYouAsync();
    public abstract Task RespondToWhoIsCuterYouOrMeAsync();
    public abstract Task RespondToWhatIsYourNameAsync();
    public abstract Task RespondToWhoIsSmarterYouOrMeAsync();
    public abstract Task RespondToWhoIsYourBossAsync();
    public abstract Task RespondToWhoMadeYouAsync();
    public abstract Task RespondToMyBadAsync();
    public abstract Task RespondToAreYouPlanningWorldDominationAsync();
    public abstract Task RespondToYouAreFunnyAsync();
    public abstract Task RespondToYouAreRightAsync();
    public abstract Task RespondToYouAreSmartAsync();
    public abstract Task RespondToYouAreStupidAsync();
    public abstract Task RespondToYouAreUglyAsync();
    public abstract Task RespondToYouHateMeAsync();
    public abstract Task RespondToYouAreFiredAsync();
    public abstract Task RespondToYouAreNotHelpfulAsync();
    public abstract Task RespondToYouAreNotMakingSenseAsync();
    public abstract Task RespondToYouAreWelcomeAsync();

    protected async Task ReplyAsync(string message)
    {
        await Context.SendActivityAsync(message);
    }
}