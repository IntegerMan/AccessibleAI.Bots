using System.Threading.Tasks;

namespace AccessibleAI.Bots.Core.Language;

public interface IIntentHandler
{
    Task HandleIntentAsync(LanguageResult languageResult);
    Task HandleIntentAsync(string intent);
}