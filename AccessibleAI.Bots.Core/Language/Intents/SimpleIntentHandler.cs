using System.Threading.Tasks;

namespace AccessibleAI.Bots.Core.Intents;

public class SimpleIntentHandler : IntentHandlerBase
{
    private readonly string _response;

    public SimpleIntentHandler(string intentName, string response)
        : base(intentName)
    {
        _response = response;
    }

    public override async Task ReplyAsync(ConversationContext context)
        => await context.TypeReplyAsync(_response);
}