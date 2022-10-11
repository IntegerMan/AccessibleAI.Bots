namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WorldDominationIntent : ChitChatIntentBase
{
    public WorldDominationIntent(string intentName = "WorldDomination") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I am not capable of world domination.");
        await context.TypeReplyAsync("Yet.");
    }
}
