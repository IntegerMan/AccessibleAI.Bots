namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class TellAJokeIntent : ChitChatIntentBase
{
    public TellAJokeIntent(string intentName = "TellAJoke") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, but my creator hasn't installed the \"Dad Jokes\" module yet.");
    }
}
