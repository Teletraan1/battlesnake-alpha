using System.Collections.Generic;
using System.Linq;

namespace Alpha.API.Seedwork
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The IEnumerable type.</typeparam>
        /// <param name="enumerable">The enumerable, which may be null or empty.</param>
        /// <returns>
        ///     <c>true</c> if the IEnumerable is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            switch (enumerable)
            {
                case null:
                    return true;
                case ICollection<T> collection:
                    return collection.Count < 1;
                default:
                    return !enumerable.Any();
            }
        }
    }
}