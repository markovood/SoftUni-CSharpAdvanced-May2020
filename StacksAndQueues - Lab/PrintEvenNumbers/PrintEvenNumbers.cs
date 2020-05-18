using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    public class PrintEvenNumbers
    {
        private static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);
            Queue<int> evenNumbers = new Queue<int>();

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
