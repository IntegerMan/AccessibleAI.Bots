namespace AccessibleAI.Bots.LanguageUnderstanding.Models;

public interface IIntentResolver
{
    LanguageResult? FindIntent(string utterance);
}