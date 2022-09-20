namespace AccessibleAI.Bots.Core.Language;

public interface IIntentResolver
{
    LanguageResult? FindIntent(string utterance);
}