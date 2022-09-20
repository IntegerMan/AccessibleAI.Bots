using System;
using Azure;
using Azure.Data.Tables;

namespace AccessibleAI.Bots.Tables;

/// <summary>
/// A repository for looking up information from Azure Table Storage
/// </summary>
public class TableEntityRepository
{
    private readonly TableClient _tableClient;
    private readonly string _defaultPartitionKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="TableEntityRepository"/> class.
    /// </summary>
    /// <param name="storageConnStr">The Azure Storage connection string</param>
    /// <param name="tableName">The name of the table within the Azure Storage account</param>
    /// <param name="defaultPartitionKey">The partition key to use when none is specified in FindEntity</param>
    public TableEntityRepository(string storageConnStr, string tableName, string defaultPartitionKey)
    {
        _tableClient = new TableClient(storageConnStr, tableName);

        _defaultPartitionKey = defaultPartitionKey;
    }

    /// <summary>
    /// Gets the TableEntity for the specified key from Azure Table Storage using the repository's settings.
    /// </summary>
    /// <param name="rowKey">The row key to look up</param>
    /// <param name="partitionKey">The partition key within the table. If none is specified, the default partition key will be used</param>
    /// <returns>The TableEntity or null if the resource could not be found</returns>
    public TableEntity? FindEntity(string rowKey, string? partitionKey = null) => FindEntity<TableEntity>(rowKey, partitionKey);

    /// <summary>
    /// Gets the generic entity for the specified key from Azure Table Storage using the repository's settings.
    /// </summary>
    /// <param name="rowKey">The row key to look up</param>
    /// <param name="partitionKey">The partition key within the table. If none is specified, the default partition key will be used</param>
    /// <returns>The generic entity or null if the resource could not be found</returns>
    public T? FindEntity<T>(string rowKey, string? partitionKey = null) where T:class, ITableEntity, new()
    {
        partitionKey ??= _defaultPartitionKey;

        try
        {
            Response<T> response = _tableClient.GetEntity<T>(partitionKey, rowKey);
            return response.Value;
        }
        catch (RequestFailedException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the definition for the specified key from Azure Table Storage using the repository's settings.
    /// </summary>
    /// <param name="rowKey">The row key to look up</param>
    /// <param name="partitionKey">The partition key within the table. If none is specified, the default partition key will be used</param>
    /// <returns>The definition or null if the resource could not be found</returns>
    public Definition? FindDefinition(string rowKey, string? partitionKey = null)
        => FindEntity(rowKey, te => new Definition(te), partitionKey: partitionKey);
        
    /// <summary>
    /// Gets the entity for the specified key from Azure Table Storage using the repository's settings.
    /// </summary>
    /// <param name="rowKey">The row key to look up</param>
    /// <param name="transformer">The function to transform from a TableEntity into the desired type</param>
    /// <param name="partitionKey">The partition key within the table. If none is specified, the default partition key will be used</param>
    /// <returns>The definition or null if the resource could not be found</returns>
    public T? FindEntity<T>(string rowKey, Func<TableEntity, T> transformer, string? partitionKey = null) where T:class
    {
        partitionKey ??= _defaultPartitionKey;

        try
        {
            Response<TableEntity> response = _tableClient.GetEntity<TableEntity>(partitionKey, rowKey);
            return transformer(response.Value);
        }
        catch (RequestFailedException)
        {
            return null;
        }
    }
}