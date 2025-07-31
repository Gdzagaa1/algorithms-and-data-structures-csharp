using System;
using Algorithms.Searching;

namespace AlgorithmsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🚀 Welcome to C# Algorithms & Data Structures Learning!");
            Console.WriteLine("=".PadRight(55, '='));
            Console.WriteLine();

            // Run Binary Search demo
            BinarySearch.Demo();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}