using Azure.Data.Tables;

namespace AccessibleAI.Bots.Tables;

/// <summary>
/// Extensions for the TableEntity class in Azure Table Storage
/// </summary>
public static class TableEntityExtensions
{
    /// <summary>
    /// Tries to get a string out of a property which may or may not exist and returns null if it is not present.
    /// </summary>
    /// <param name="entity">The TableEntity to check</param>
    /// <param name="key">The key to check</param>
    /// <returns>The value or null if not present</returns>
    public static string? TryGetString(this TableEntity entity, string key)
    {
        return entity.TryGetValue(key, out object? value) ? value?.ToString() : null;
    }
        
}