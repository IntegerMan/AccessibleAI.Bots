namespace AccessibleAI.Bots.Core.Language;

public interface IIntentResolver
{
    IntentResolutionResult FindIntent(string utterance);
}