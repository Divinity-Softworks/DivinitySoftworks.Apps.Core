namespace System.Collections.ObjectModel {
    /// <summary>
    /// Represents a fixed dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. Removes the first item in the collection when an item is added that exceeds the <see cref="Capacity"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class FixedObservableCollection<T> : ObservableCollection<T> {
        
        /// <summary>
        /// Represents a fixed dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. Removes the first item in the collection when an item is added that exceeds the <see cref="Capacity"/>.
        /// </summary>
        public FixedObservableCollection()
            : base() {

        }

        /// <summary>
        /// The maximum number of items to hold.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Represents a fixed dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. Removes the first item in the collection when an item is added that exceeds the <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The maximum number of items to hold.</param>
        public FixedObservableCollection(int capacity) {
            Capacity = capacity;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="FixedObservableCollection{T}"/>. Removes the first item in the collection when an item is added that exceeds the <see cref="Capacity"/>.
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="FixedObservableCollection{T}"/>. The value can be null for reference types.</param>
        public new void Add(T item) {
            if (Count >= Capacity)
                RemoveAt(0);

            base.Add(item);
        }
    }
}