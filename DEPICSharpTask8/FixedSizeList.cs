namespace DEPICSharpTask8
{
    // Q5: Generic list with a fixed capacity
    public class FixedSizeList<T>
    {
        private readonly T[] items;
        private int count;

        public int Capacity => items.Length;
        public int Count => count;

        // Q5.2: constructor takes the fixed capacity
        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            items = new T[capacity];
            count = 0;
        }

        // Q5.3: adds an element, throws if the list is already full
        public void Add(T item)
        {
            if (count == Capacity)
                throw new InvalidOperationException($"The list is full. Maximum capacity is {Capacity} element(s).");

            items[count] = item;
            count++;
        }

        // Q5.4: gets the element at the index, throws for invalid indices
        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Invalid index {index}. Valid indices are from 0 to {count - 1} (Count = {count}).");

            return items[index];
        }
    }
}
