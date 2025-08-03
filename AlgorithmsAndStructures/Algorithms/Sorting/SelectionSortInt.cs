using System;

namespace Algorithms.Sorting
{
    
    /*
     * My implementation of Selection Sort Algorithm
     * Book: Grokking Algorithms(Chapter 2)
     *
     * A simple sorting algorithm that repeatedly finds the minimum element
     * and places it at the beginning of the unsorted portion.
     *
     * Time Complexity: O(n²)

     */
    public class SelectionSortInt
    {
        
        public static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int smallestIndex = FindSmallest(arr, i);
                int temp = arr[smallestIndex];
                arr[smallestIndex] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }

        private static int FindSmallest(int[] arr, int index)
        {
            int currInd = index;
            int curr = arr[index];
            
            for (int j = index + 1; j < arr.Length; j++)
            {
                if (curr > arr[j])
                {
                    curr = arr[j];
                    currInd = j;
                }
                
                
            }
            return currInd;
        }
        
        
        public static void Demo()
        {
            Console.WriteLine("=== Selection Sort Demo ===");
            int[] unsortedArray = { 64, 25, 12, 22, 11, 90 };
    
            Console.WriteLine($"Original: [{string.Join(", ", unsortedArray)}]");
    
            int[] sortedArray = SelectionSort(unsortedArray);
    
            Console.WriteLine($"Sorted:   [{string.Join(", ", sortedArray)}]");
        }
        
    }
}