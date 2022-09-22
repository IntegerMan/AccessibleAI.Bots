using System.Collections.Generic;

namespace AccessibleAI.Bots.Language.Levenshtein;

public interface ILevenshteinEntityProvider
{
    IEnumerable<LevenshteinEntry> GetEntries();
}