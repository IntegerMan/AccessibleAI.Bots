using System.Threading.Tasks;

namespace AccessibleAI.Bots.Core.Language;

public interface IIntentHandler
{
    Task HandleIntentAsync(ConversationContext context, string? intentName = null);
}