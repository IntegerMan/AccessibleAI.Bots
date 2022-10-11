namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class AskMeAQuestionIntent : ChitChatIntentBase
{
    public AskMeAQuestionIntent(string intentName = "AskMeAQuestion") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not good at asking questions. Ask me something instead.");
    }
}
