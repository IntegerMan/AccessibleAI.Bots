using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Core.Language;

/// <summary>
/// Represents the result of trying to resolve an utterance via CLU or Orchestration.
/// </summary>
public class IntentResolutionResult
{
    private readonly Dictionary<string, EntityMatch> _entities = new();
    private readonly List<IntentMatch> _intents = new();

    public IntentResolutionResult(string intentName = "None", string orchestrationIntentName = "None")
    {
        OrchestrationIntentName = orchestrationIntentName;
        IntentName = intentName;
    }

    /// <summary>
    /// Gets or sets the intent name used for resolving orchestration intents.
    /// This will be None if an orchestration flow was not used.
    /// </summary>
    public string OrchestrationIntentName { get; set; }

    /// <summary>
    /// Gets or sets the intent name of the matching intent. This will not include the orchestration name, if one was present.
    /// </summary>
    public string IntentName { get; set; }
        
    /// <summary>
    /// Gets the confidence score for the given low-level intent.
    /// </summary>
    public double ConfidenceScore => TopIntent?.ConfidenceScore ?? 0;

    /// <summary>
    /// Gets the IntentMatch representing the low-level intent
    /// </summary>
    public IntentMatch? TopIntent => _intents.FirstOrDefault(i => i.Category == IntentName);

    public IEnumerable<EntityMatch> Entities => _entities.Values.OrderBy(e => e.Category);

    public IOrderedEnumerable<IntentMatch> Intents => _intents.OrderByDescending(i => i.ConfidenceScore);


    public static IntentResolutionResult NoneIntent { get; } = new("None", "None");

    /// <summary>
    /// Adds an entity to the result
    /// </summary>
    /// <param name="entity">The entity to add</param>
    public void AddEntity(EntityMatch entity)
    {
        _entities[entity.Category] = entity;
    }

    /// <summary>
    /// Adds a matching intent to the result
    /// </summary>
    /// <param name="intentMatch">The intent match to add</param>
    public void AddMatchingIntent(IntentMatch intentMatch)
    {
        _intents.Add(intentMatch);
    }

    /// <summary>
    /// Gets an entity match by a category or null if one was not present.
    /// </summary>
    /// <param name="category">The category</param>
    /// <returns>The entity match, or null</returns>
    public EntityMatch? GetEntity(string category) 
        => _entities.ContainsKey(category) 
            ? _entities[category] 
            : null;

    /// <inheritdoc />
    public override string ToString() => TopIntent?.ToString() ?? "No Match";

    public string IntentKey 
        => TopIntent switch
            {
                null => "None/None",
                _ => $"{TopIntent.OrchestrationName}/{TopIntent.Category}"
            };
}