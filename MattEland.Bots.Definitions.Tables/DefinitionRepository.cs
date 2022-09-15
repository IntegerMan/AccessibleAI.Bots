using Azure;
using Azure.Data.Tables;

namespace MattEland.Bots.Definitions.Tables
{
    /// <summary>
    /// A repository for looking up information from Azure Table Storage
    /// </summary>
    public class DefinitionRepository
    {
        private readonly TableClient _tableClient;
        private readonly string _defaultPartitionKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinitionRepository"/> class.
        /// </summary>
        /// <param name="storageConnStr">The Azure Storage connection string</param>
        /// <param name="tableName">The name of the table within the Azure Storage account</param>
        /// <param name="defaultPartitionKey">The partition key to use when none is specified in LookupDefinition</param>
        public DefinitionRepository(string storageConnStr, string tableName, string defaultPartitionKey)
        {
            _tableClient = new TableClient(storageConnStr, tableName);

            _defaultPartitionKey = defaultPartitionKey;
        }

        /// <summary>
        /// Gets the definition for the specified term key from Azure Table Storage using the repository's settings.
        /// </summary>
        /// <param name="rowKey">The row key to look up</param>
        /// <param name="partitionKey">The partition key within the table. If none is specified, the default partition key will be used</param>
        /// <returns>The definition or null</returns>
        public Definition? LookupDefinition(string rowKey, string? partitionKey = null)
        {
            partitionKey ??= _defaultPartitionKey;

            Response<Definition?> response = _tableClient.GetEntity<Definition?>(partitionKey, rowKey);

            return response.Value;
        }
    }
}
