// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a collection of extensions for enumerables, lists, and collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Updates an item within the collection.
        /// </summary>
        /// <typeparam name="T">
        /// The type of item within the collection.
        /// </typeparam>
        /// <param name="collection">
        /// The collection to update an item in.
        /// </param>
        /// <param name="item">
        /// The item to update.
        /// </param>
        /// <param name="predicate">
        /// The function to find the item within the <paramref name="collection"/>.
        /// </param>
        /// <returns>
        /// True if the item has been updated; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="item"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
        public static bool Update<T>(this IList<T> collection, T item, Func<T, T, bool> predicate)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            T existing = collection.FirstOrDefault(x => predicate.Invoke(x, item));
            if (existing == null)
            {
                return false;
            }

            int idx = collection.IndexOf(existing);

            collection.Remove(existing);
            collection.Insert(idx, item);
            return true;
        }
    }
}