using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class RecursiveArraySum
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(arr, 0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] arr, int startIndex)
        {
            if (startIndex == arr.Length - 1)
            {
                return arr[startIndex];
            }

            // use of more variables for comprehensive debugging
            int currentInt = arr[startIndex];
            int currentSum = Sum(arr, startIndex + 1);
            int totalSum = currentInt + currentSum;

            return totalSum;
        }
    }
}