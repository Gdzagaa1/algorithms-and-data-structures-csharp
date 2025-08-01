using System;

namespace Algorithms.Searching
{

    /*
     * My implementation of Binary Search Algorithm (Integer).
     * Book: Grokking Algorithms (Chapter 1)
     *
     * A search algorithm that finds the position of a target value in a sorted array
     * by repeatedly dividing the search interval in half.
     *
     * Time Complexity: O(log n)
     */

    public class BinarySearchInt
    {
        // Searches for target in a sorted array, returns index if found or -1 if not found
        public static int BinarySearch(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;
            
            int lowIndex = 0;
            int highIndex = arr.Length - 1;

            while (lowIndex <= highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;

                if (arr[middleIndex] == target) return middleIndex;
                if (target > arr[middleIndex])
                {
                    lowIndex = middleIndex + 1;
                }
                else
                {
                    highIndex = middleIndex - 1;
                }
            }
            
            return -1;
        }

        // Demonstrate the binary search.
        public static void Demo()
        {
            Console.WriteLine("=== Binary Search Demo ===");
            int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
    
            Console.WriteLine($"Array: [{string.Join(", ", sortedArray)}]");
    
            // Test found
            int result1 = BinarySearch(sortedArray, 7);
            Console.WriteLine($"Search for 7: {(result1 != -1 ? $"Found at index {result1}" : "Not found")}");
    
            // Test not found
            int result2 = BinarySearch(sortedArray, 40);
            Console.WriteLine($"Search for 40: {(result2 != -1 ? $"Found at index {result2}" : "Not found")}");
        }
    }
}