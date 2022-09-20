using System.Threading.Tasks;

namespace AccessibleAI.Bots.LanguageUnderstanding.Models;

public interface IIntentHandler
{
    Task HandleIntentAsync(LanguageResult languageResult);
    Task HandleIntentAsync(string intent);
}