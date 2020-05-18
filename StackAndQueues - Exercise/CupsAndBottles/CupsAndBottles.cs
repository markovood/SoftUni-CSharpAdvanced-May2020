using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    public class CupsAndBottles
    {
        public static void Main()
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);

            int[] bottlesCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesCapacity);

            int wasted = 0;
            while (true)
            {
                if (cups.Count <= 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
                    break;
                }
                else if (bottles.Count <= 0)
                {
                    Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                    break;
                }

                int currentBtl = bottles.Peek();
                int currentCup = cups.Peek();

                while (true)
                {
                    currentCup -= currentBtl;
                    if (currentCup > 0)
                    {
                        bottles.Pop();
                        currentBtl = bottles.Peek();
                    }
                    else
                    {
                        cups.Dequeue();
                        wasted += Math.Abs(currentCup);
                        bottles.Pop();
                        break;
                    }
                }
            }

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}