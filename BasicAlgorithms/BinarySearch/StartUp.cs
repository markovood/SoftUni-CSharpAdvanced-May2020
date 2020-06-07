using System;
using System.Linq;

namespace BinarySearch
{
    public class StartUp
    {
        public static void Main()
        {
            int[] sortedArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(sortedArr);

            int searchedItem = int.Parse(Console.ReadLine());

            int foundAtIndex = BinarySearch(sortedArr, searchedItem);
            Console.WriteLine(foundAtIndex);
        }

        public static int BinarySearch<T>(T[] sortedArr, T element) where T : IComparable<T>
        {
            int leftEnd = 0;
            int rightEnd = sortedArr.Length - 1;

            while (leftEnd <= rightEnd)
            {
                int mid = (leftEnd + rightEnd) / 2;
                if (sortedArr[mid].CompareTo(element) < 0)
                {
                    // search to the left
                    leftEnd = mid + 1;
                }
                else if (sortedArr[mid].CompareTo(element) > 0)
                {
                    // search to the right
                    rightEnd = mid - 1;
                }
                else
                {
                    return mid;
                } 
            }

            return -1;
        }
    }
}
