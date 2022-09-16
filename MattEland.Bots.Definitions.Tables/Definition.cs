using System;
using Azure;
using Azure.Data.Tables;

namespace AccessibleAI.Bots.Definitions.Tables
{
    /// <summary>
    /// Represents a definition from Azure Table Storage. This assumes that the Value and Related properties exist on the table.
    /// </summary>
    public class Definition
    {
        private readonly TableEntity _entity;

        /// <summary>
        /// Creates a new instances of the Definition class based on a Table Entity.
        /// </summary>
        /// <param name="entity">The table entity</param>
        public Definition(TableEntity entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// Custom Value information. This is the main piece of data being retrieved.
        /// </summary>
        public string? Value => _entity.TryGetValue("Value", out var value) ? value.ToString() : null;

        /// <summary>
        /// Custom related information. Use this to link to additional information. This could be a URL or comma separated list of IDs or whatever else is convenient.
        /// </summary>
        public string? Related => _entity.TryGetValue("Related", out var value) ? value.ToString() : null;


    }
}