using System.Threading.Tasks;

namespace AccessibleAI.Bots.Core.Language.Intents;

public interface IIntentHandler
{
    Task ReplyAsync(ConversationContext context);
}