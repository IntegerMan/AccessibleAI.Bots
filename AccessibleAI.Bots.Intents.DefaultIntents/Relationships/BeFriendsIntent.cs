namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class BeFriendsIntent : ChitChatIntentBase
{
    public BeFriendsIntent(string intentName = "BeFriends") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm happy to be your friend.");
    }
}
