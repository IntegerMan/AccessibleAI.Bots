using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Language.Levenshtein;

public class AggregateLevenshteinEntityProvider : ILevenshteinEntityProvider, ICollection<ILevenshteinEntityProvider>
{
    private readonly List<ILevenshteinEntityProvider> _providers = new();

    public int Count => _providers.Count;

    public bool IsReadOnly => false;

    public void Add(ILevenshteinEntityProvider item)
    {
        _providers.Add(item);
    }

    private InMemoryLevenshteinEntityProvider? _inMemoryEntities;

    /// <summary>
    /// Adds a manual entry to the list of Levenshtein Entries. This will be stored in-memory and will not be persisted to disk.
    /// </summary>
    /// <param name="entry">The entry to add.</param>
    /// <exception cref="ArgumentNullException">Thrown if entry was null.</exception>
    public void AddEntry(LevenshteinEntry entry)
    {
        if (entry is null)
        {
            throw new ArgumentNullException(nameof(entry));
        }

        if (_inMemoryEntities == null)
        {
            _inMemoryEntities = new();
            _providers.Add(_inMemoryEntities);
        }

        _inMemoryEntities.Add(entry);
    }

    /// <summary>
    /// Adds a series of manual entries to the list of Levenshtein Entries. These will be stored in-memory and will not be persisted to disk.
    /// </summary>
    /// <param name="entries">The entries to add.</param>
    public void AddEntries(IEnumerable<LevenshteinEntry> entries)
    {
        if (_inMemoryEntities == null)
        {
            _inMemoryEntities = new();
            _providers.Add(_inMemoryEntities);
        }

        _inMemoryEntities.AddRange(entries.Where(e => e is not null));
    }

    public void Clear()
    {
        _providers.Clear();
        _inMemoryEntities = null;
    }

    public bool Contains(ILevenshteinEntityProvider item)
    {
        return _providers.Contains(item);
    }

    public void CopyTo(ILevenshteinEntityProvider[] array, int arrayIndex)
    {
        _providers.CopyTo(array, arrayIndex);
    }

    public IEnumerable<LevenshteinEntry> GetEntries()
    {
        foreach (var provider in _providers)
        {
            foreach (var entry in provider.GetEntries())
            {
                yield return entry;
            }
        }
    }

    public IEnumerator<ILevenshteinEntityProvider> GetEnumerator()
    {
        return _providers.GetEnumerator();
    }

    public bool Remove(ILevenshteinEntityProvider item)
    {
        if (item == _inMemoryEntities)
        {
            _inMemoryEntities = null;
        }

        return _providers.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _providers.GetEnumerator();
    }
}
