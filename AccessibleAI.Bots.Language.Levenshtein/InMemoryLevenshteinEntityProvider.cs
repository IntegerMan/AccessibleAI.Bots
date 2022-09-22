using System;
using System.Collections;
using System.Collections.Generic;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class InMemoryLevenshteinEntityProvider : ILevenshteinEntityProvider, ICollection<LevenshteinEntry>
{
    private readonly HashSet<LevenshteinEntry> _entries = new();

    public InMemoryLevenshteinEntityProvider()
    {
    }

    public InMemoryLevenshteinEntityProvider(IEnumerable<LevenshteinEntry> entries)
    {
        AddRange(entries);
    }

    public int Count => _entries.Count;

    public bool IsReadOnly => ((ICollection<LevenshteinEntry>)_entries).IsReadOnly;

    public void Add(LevenshteinEntry item) => _entries.Add(item);

    public void AddRange(IEnumerable<LevenshteinEntry> items)
    {
        foreach (var item in items)
        {
            _entries.Add(item);
        }
    }

    public void Clear() => _entries.Clear();

    public bool Contains(LevenshteinEntry item) => _entries.Contains(item);

    public void CopyTo(LevenshteinEntry[] array, int arrayIndex) => _entries.CopyTo(array, arrayIndex);

    public IEnumerable<LevenshteinEntry> GetEntries() => _entries;

    public IEnumerator<LevenshteinEntry> GetEnumerator() => _entries.GetEnumerator();

    public bool Remove(LevenshteinEntry item) => _entries.Remove(item);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
