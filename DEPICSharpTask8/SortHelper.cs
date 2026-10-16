namespace DEPICSharpTask8
{
    // Same idea as Helper<T> from the session: generic class constrained with IComparable<T>
    public class SortHelper<T> where T : IComparable<T>
    {
        // Q1: Optimized Bubble Sort
        // Optimization 1 (early exit): if a full pass makes NO swap, the array is already sorted -> stop.
        //   Best case (already sorted array) becomes O(N) instead of O(N^2).
        // Optimization 2 (shrinking boundary): remember the index of the LAST swap in each pass.
        //   Everything after it is already in its final place, so the next pass stops there.
        // Worst and average cases are still O(N^2), but far fewer comparisons are done in practice.
        public static void OptimizedBubbleSort(T[] arr)
        {
            if (arr is null) // Guard Clause
                return;

            int n = arr.Length;

            while (n > 1)
            {
                int lastSwapIndex = 0; // 0 => no swap happened in this pass

                for (int j = 1; j < n; j++)
                {
                    // CompareTo only guarantees the SIGN (positive / zero / negative), so use > 0 (not == 1)
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        T temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;

                        lastSwapIndex = j;
                    }
                }

                // No swap => lastSwapIndex = 0 => n = 0 => loop ends (early exit)
                n = lastSwapIndex;
            }
        }
    }
}
