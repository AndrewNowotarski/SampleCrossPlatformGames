using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ExtensionMethods
{
    /// <summary>
    /// Helper extension methods to randomize IEnumerables.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Method to return a random entry from an enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable.</typeparam>
        /// <param name="source">Enumerable collection to use.</param>
        /// <returns>Returns an entry from the source enumerable at random.</returns>
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        /// <summary>
        /// Method to return a random entry from an enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable.</typeparam>
        /// <param name="source">Enumerable collection to use.</param>
        /// <returns>Returns <x> entries from the source enumerable at random.</returns>
        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        /// <summary>
        /// Shuffles the enumerable source.
        /// </summary>
        /// <typeparam name="T">Type of the enumerable.</typeparam>
        /// <param name="source">Enumerable collection to use.</param>
        /// <returns>Returns a shuffled enumerable</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
