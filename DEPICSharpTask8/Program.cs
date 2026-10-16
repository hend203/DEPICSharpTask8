using System.Collections;

namespace DEPICSharpTask8
{
    internal class Program
    {
        // Q3: Reverse the ArrayList IN PLACE (same ArrayList) without using the built-in Reverse
        private static void ReverseArrayList(ArrayList arrayList)
        {
            if (arrayList is null) // Guard Clause
                return;

            int left = 0;
            int right = arrayList.Count - 1;

            while (left < right) // two pointers moving toward the middle
            {
                object? temp = arrayList[left];
                arrayList[left] = arrayList[right];
                arrayList[right] = temp;

                left++;
                right--;
            }
        }

        // Q4: Returns a NEW list that contains only the even numbers of the given list
        private static List<int> GetEvenNumbers(List<int> list)
        {
            List<int> evenNumbers = new List<int>();

            foreach (int num in list)
            {
                if (num % 2 == 0)
                    evenNumbers.Add(num);
            }

            return evenNumbers;
        }

        // Q6: Index of the first non-repeated character, or -1 if there is none
        private static int FirstNonRepeatedChar(string text)
        {
            if (string.IsNullOrEmpty(text)) // Guard Clause
                return -1;

            // Pass 1: count the occurrences of each character
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char ch in text)
            {
                if (counts.ContainsKey(ch))
                    counts[ch]++;
                else
                    counts.Add(ch, 1);
            }

            // Pass 2: the first character that appears only once
            for (int i = 0; i < text.Length; i++)
            {
                if (counts[text[i]] == 1)
                    return i;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            #region Q1 - Optimized Bubble Sort
            int[] arr = { 10, 2, 3, -1, 5, 0, 1, 3, 8, -2 };

            SortHelper<int>.OptimizedBubbleSort(arr);

            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();

            string[] names = { "Hend", "Ahmed", "Mariam" };
            SortHelper<string>.OptimizedBubbleSort(names); // works with any IComparable<T> (Point too)
            Console.WriteLine(string.Join(", ", names));
            #endregion

            #region Q2 - Range<T>
            Range<int> intRange = new Range<int>(10, 50);

            Console.WriteLine($"IsInRange(25): {intRange.IsInRange(25)}");  // True
            Console.WriteLine($"IsInRange(60): {intRange.IsInRange(60)}");  // False
            Console.WriteLine($"Length: {intRange.Length()}");              // 40

            Range<double> doubleRange = new Range<double>(1.5, 4.0);
            Console.WriteLine($"Length: {doubleRange.Length()}");           // 2.5
            #endregion

            #region Q3 - Reverse an ArrayList in place
            ArrayList arrayList = new ArrayList { 1, 2, 3, "Ahmed", 5.5 };

            Console.WriteLine(arrayList.GetHashCode());
            ReverseArrayList(arrayList);
            Console.WriteLine(arrayList.GetHashCode()); // same hash code => same ArrayList object (in place)

            foreach (var item in arrayList)
                Console.WriteLine(item);
            #endregion

            #region Q4 - Even numbers
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> evens = GetEvenNumbers(nums);

            foreach (int num in evens)
                Console.Write(num + " "); // 2 4 6 8 10
            Console.WriteLine();
            #endregion

            #region Q5 - FixedSizeList<T>
            FixedSizeList<string> fixedList = new FixedSizeList<string>(2);

            fixedList.Add("A");
            fixedList.Add("B");

            try
            {
                fixedList.Add("C"); // exceeds the capacity
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                fixedList.Get(5); // invalid index
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(fixedList.Get(1)); // B
            #endregion

            #region Q6 - First non-repeated character
            Console.WriteLine(FirstNonRepeatedChar("leetcode"));     // 0
            Console.WriteLine(FirstNonRepeatedChar("loveleetcode")); // 2
            Console.WriteLine(FirstNonRepeatedChar("aabb"));         // -1
            #endregion
        }
    }
}
