namespace DEPICSharpTask8
{
    // Q2: Generic Range<T>, T is assumed to implement IComparable<T> (as the assignment says)
    public class Range<T> where T : IComparable<T>
    {
        public T Min { get; }
        public T Max { get; }

        // Q2.2: constructor that takes the minimum and maximum values
        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("Minimum value cannot be greater than the maximum value.");

            Min = min;
            Max = max;
        }

        // Q2.3: true if Min <= value <= Max
        public bool IsInRange(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        // Q2.4: length of the range = Max - Min
        // IComparable<T> does NOT give us the "-" operator, so we use dynamic:
        // the subtraction is resolved at RUN time and works for numeric types (int, long, double, decimal).
        // (Type-safe alternative on .NET 7+: add "ISubtractionOperators<T, T, T>" to the constraint and write Max - Min.)
        public T Length()
        {
            return (dynamic)Max - (dynamic)Min;
        }
    }
}
