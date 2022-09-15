using System.Collections.Generic;
using System.Linq;

namespace MattEland.Bots.CluHelpers
{
    public class CluResult
    {
        private readonly Dictionary<string, EntityMatch> _entities = new();
        private readonly List<IntentMatch> _intents = new();

        public string TopIntent { get; set; }
        public double ConfidenceScore => _intents.FirstOrDefault(i => i.Category == TopIntent)?.ConfidenceScore ?? 0;

        public IEnumerable<EntityMatch> Entities => _entities.Values.OrderBy(e => e.Category);

        public string Json { get; internal set; }

        public void AddEntity(EntityMatch entity)
        {
            _entities[entity.Category] = entity;
        }

        public void AddMatchingIntent(IntentMatch intentMatch)
        {
            _intents.Add(intentMatch);
        }

        public EntityMatch? GetEntity(string v)
        {
            if (_entities.ContainsKey(v))
            {
                return _entities[v];
            }

            return null;
        }
    }
}
