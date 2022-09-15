using System;
using Azure;
using Azure.Data.Tables;

namespace MattEland.Bots.Definitions.Tables
{
    /// <summary>
    /// Represents a definition from Azure Table Storage. This assumes that the Value and Related properties exist on the table.
    /// </summary>
    public class Definition : ITableEntity
    {
        /// <summary>
        /// Custom Value information. This is the main piece of data being retrieved.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Custom related information. Use this to link to additional information. This could be a URL or comma separated list of IDs or whatever else is convenient.
        /// </summary>
        public string? Related { get; set; }
        /// <summary>
        /// The partition key in the table
        /// </summary>
        public string? PartitionKey { get; set; }
        
        /// <summary>
        /// The row key in the table
        /// </summary>
        public string? RowKey { get; set; }

        /// <summary>
        /// The timestamp for the row
        /// </summary>
        public DateTimeOffset? Timestamp { get; set; }
        
        /// <summary>
        /// The row's modification ETag
        /// </summary>
        public ETag ETag { get; set; }
    }
}