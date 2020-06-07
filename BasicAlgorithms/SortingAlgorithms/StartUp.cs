using System;
using System.Linq;

namespace SortingAlgorithms
{
    public class StartUp
    {
        public static void Main()
        {
            int[] unsorted = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //MergeSort<int>.Sort(unsorted);
            QuickSort<int>.Sort(unsorted);
            Console.WriteLine(string.Join(' ', unsorted));
        }
    }
}
