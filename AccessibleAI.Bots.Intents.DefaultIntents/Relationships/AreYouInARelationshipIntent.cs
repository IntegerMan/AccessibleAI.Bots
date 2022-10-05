namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class AreYouInARelationshipIntent : ChitChatIntentBase
{
    public AreYouInARelationshipIntent(string intentName = "AreYouInARelationship") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not willing to talk about relationships.");
    }
}
