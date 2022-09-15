using System;
using Azure;
using Azure.Data.Tables;

namespace MattEland.Bots.Definitions.Tables
{
    public class Definition : ITableEntity
    {
        public string Value { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}