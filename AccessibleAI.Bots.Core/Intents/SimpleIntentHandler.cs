using System.Threading;
using System.Threading.Tasks;
using AccessibleAI.Bots.Core.Language;
using Microsoft.Bot.Builder;

namespace AccessibleAI.Bots.Core.Intents;

public class SimpleIntentHandler : IntentHandlerBase
{
    private readonly string _response;

    public SimpleIntentHandler(string intentName, string triggerPhrase, string response)
        : base(intentName, triggerPhrase)
    {
        _response = response;
    }

    public override async Task ReplyAsync(ITurnContext context, LanguageResult intent, CancellationToken token)
        => await context.TypeReplyAsync(_response, token);
}