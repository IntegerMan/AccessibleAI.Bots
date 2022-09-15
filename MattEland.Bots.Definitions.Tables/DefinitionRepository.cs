using Azure;
using Azure.Data.Tables;

namespace MattEland.Bots.Definitions.Tables
{
    public class DefinitionRepository
    {
        private readonly TableClient _tableClient;
        private readonly string _partitionKey;

        public DefinitionRepository(string storageConnStr, string tableName, string partitionKey)
        {
            _tableClient = new TableClient(storageConnStr, tableName);

            _partitionKey = partitionKey;
        }

        public string LookupDefinition(string termKey)
        {
            Response<Definition> response = _tableClient.GetEntity<Definition>(_partitionKey, termKey);

            Definition def = response.Value;

            return def.Value;
        }
    }
}
