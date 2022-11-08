namespace System.Collections.ObjectModel {
    /// <summary>
    /// Extentions for the <seealso cref="ObservableCollection{T}"/> type.
    /// </summary>
    public static class ObservableCollectionExtensions {
        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T">The <seealso cref="Predicate{T}"/> delegate that defines the conditions of the elements to</typeparam>
        /// <param name="collection">The collection to remove elements from.</param>
        /// <param name="match">The <seealso cref="Predicate{T}"/> delegate that defines the conditions of the elements to remove.</param>
        public static void RemoveAll<T>(this ObservableCollection<T> collection, Predicate<T> match) {
            for (int i = collection.Count - 1; i >= 0; i--) {
                if (match(collection[i]))
                    collection.RemoveAt(i);
            }
        }
    }
}
