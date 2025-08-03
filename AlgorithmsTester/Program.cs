using System;
using Algorithms.DataStructures.HashTable;
using Algorithms.Searching;
using Algorithms.Sorting;

namespace AlgorithmsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSearching();
            RunSorting();
            RunHashTable();
        }

        static void RunHashTable()
        {
            Console.WriteLine();
            HashTableDemo.Demo();
            Console.WriteLine();
        }

        static void RunSorting()
        {
            Console.WriteLine();
            SelectionSortInt.Demo();
            Console.WriteLine();
            
            Console.WriteLine();
            QuickSortInt.Demo();
            Console.WriteLine();
            
        }

        static void RunSearching()
        {
            Console.WriteLine();
            BinarySearchInt.Demo();
            Console.WriteLine();
        }
    }
}