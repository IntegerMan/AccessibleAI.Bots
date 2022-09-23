using System.Text.Json;
using AccessibleAI.Bots.Core.Language;

namespace AccessibleAI.Bots.LanguageUnderstanding.Helpers;

internal static class IntentLoadHelpers
{
    internal static void ExtractIntents(IntentResolutionResult result, JsonElement intents)
    {
        foreach (JsonElement intentJson in intents.EnumerateArray())
        {
            IntentMatch intentMatch = new()
            {
                Category = intentJson.GetProperty("category").ToString(),
                ConfidenceScore = intentJson.GetProperty("confidenceScore").GetSingle(),
                MatchDetails = null, // Can't think of anything to put here, but we could if we had more contextual information
            };

            result.AddMatchingIntent(intentMatch);
        }
    }    
    
    internal static void ExtractEntities(IntentResolutionResult result, JsonElement entities)
    {
        foreach (JsonElement entityJson in entities.EnumerateArray())
        {
            EntityMatch entity = new()
            {
                Category = entityJson.GetProperty("category").GetString()!,
                Text = entityJson.GetProperty("text").GetString()!,
                Offset = entityJson.GetProperty("offset").GetInt32(),
                Length = entityJson.GetProperty("length").GetInt32(),
                ConfidenceScore = entityJson.GetProperty("confidenceScore").GetSingle()
            };

            if (entityJson.TryGetProperty("extraInformation", out JsonElement extraInfo))
            {
                foreach (JsonElement info in extraInfo.EnumerateArray())
                {
                    string kind = info.GetProperty("extraInformationKind").GetString()!;
                    if (kind == "ListKey")
                    {
                        entity.ListKey = info.GetProperty("key").GetString()!;
                    }
                }
            }

            result.AddEntity(entity);
        }
    }
}