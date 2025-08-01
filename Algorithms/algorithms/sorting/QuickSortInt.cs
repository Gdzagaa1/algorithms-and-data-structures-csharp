namespace Algorithms.Sorting;



/*
 * My implementation of QuickSort Algorithm
 * Book: Grokking Algorithms (Chapter 4)
 *
 * A simple divide-and-conquer sorting algorithm that picks a pivot element
 * and partitions the array around it, then recursively sorts the partitions.
 *
 * Average Time Complexity: O(n log n)
 * Worst Time Complexity: O(n²)
 */

public class QuickSortInt
{
    public static List<int> QuickSort(List<int> arr)
    {
        if (arr.Count < 2) return arr;

        int pivot = arr[0];
        List<int> less = new List<int>();
        List<int> greater = new List<int>();
        
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] <= pivot) less.Add(arr[i]);
            if (arr[i] > pivot) greater.Add(arr[i]);
        }

        List<int> res = QuickSort(less);
        res.Add(pivot);
        List<int> res2 = QuickSort(greater);
        res.AddRange(res2);

        return res;
    }
    
    
    public static void Demo()
    {
        Console.WriteLine("=== Quick Sort Demo ===");
        List<int> unsorted1 = new List<int> { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"Original: [{string.Join(", ", unsorted1)}]");
    
        List<int> sorted1 = QuickSort(new List<int>(unsorted1));
        Console.WriteLine($"Sorted:   [{string.Join(", ", sorted1)}]");
        Console.WriteLine();

    }
}