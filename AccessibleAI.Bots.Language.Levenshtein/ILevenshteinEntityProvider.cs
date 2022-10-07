using AccessibleAI.Bots.Core.Language;
using System.Collections.Generic;

namespace AccessibleAI.Bots.Language.Levenshtein;

public interface ILevenshteinEntityProvider : IIntentResolver
{
    IEnumerable<LevenshteinEntry> GetEntries();
}