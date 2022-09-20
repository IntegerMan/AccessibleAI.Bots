using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessibleAI.Bots.Core.Helpers;

public static class RandomExtensions
{
    private static readonly Random Random = new Random();

    public static T RandomElement<T>(this T[] array) => array[Random.Next(array.Length)];
    public static T RandomElement<T>(this IEnumerable<T> elements) => elements.ToArray().RandomElement();
}