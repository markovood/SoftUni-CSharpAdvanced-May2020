using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    public class FastFood
    {
        public static void Main()
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            while (queue.Count != 0)
            {
                if (quantity >= queue.Peek())
                {
                    quantity -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}