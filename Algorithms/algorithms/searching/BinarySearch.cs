using System;

namespace Algorithms.Searching
{
    /// <summary>
    /// Binary Search implementation
    /// Source: Grokking Algorithms - Chapter 1
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// Searches for a target value in a sorted array
        /// Time Complexity: O(log n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="sortedArray">The sorted array to search in</param>
        /// <param name="target">The value to search for</param>
        /// <returns>Index of target if found, -1 if not found</returns>
        public static int Search(int[] sortedArray, int target)
        {
            if (sortedArray == null || sortedArray.Length == 0)
                return -1;

            int low = 0;
            int high = sortedArray.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2; // Prevent overflow
                int guess = sortedArray[mid];

                if (guess == target)
                {
                    return mid; // Found it!
                }
                else if (guess > target)
                {
                    high = mid - 1; // Target is in lower half
                }
                else
                {
                    low = mid + 1; // Target is in upper half  
                }
            }

            return -1; // Target not found
        }

        /// <summary>
        /// Demo method to test binary search
        /// </summary>
        public static void Demo()
        {
            Console.WriteLine("=== Binary Search Demo ===");
            
            int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            
            Console.WriteLine($"Array: [{string.Join(", ", sortedArray)}]");
            Console.WriteLine();

            // Test cases
            TestSearch(sortedArray, 7);   // Should find at index 3
            TestSearch(sortedArray, 1);   // Should find at index 0  
            TestSearch(sortedArray, 19);  // Should find at index 9
            TestSearch(sortedArray, 6);   // Should not find (-1)
            TestSearch(sortedArray, 20);  // Should not find (-1)
        }

        private static void TestSearch(int[] array, int target)
        {
            int result = Search(array, target);
            string message = result != -1 ? 
                $"Found {target} at index {result}" : 
                $"{target} not found in array";
            Console.WriteLine(message);
        }
    }
}