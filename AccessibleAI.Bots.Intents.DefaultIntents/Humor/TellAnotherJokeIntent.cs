namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class TellAnotherJokeIntent : ChitChatIntentBase
{
    public TellAnotherJokeIntent(string intentName = "TellAnotherJoke") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, but my creator hasn't installed the \"Dad Jokes\" module yet.");
    }
}
