using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    public class Lootbox
    {
        public static void Main()
        {
            int[] loot1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] loot2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> claimed = new List<int>();
            Queue<int> box1 = new Queue<int>(loot1);
            Stack<int> box2 = new Stack<int>(loot2);

            while (true)
            {
                if (box1.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (box2.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
 
                int sum = box1.Peek() + box2.Peek();
                if (sum % 2 == 0)
                {
                    claimed.Add(sum);
                    box1.Dequeue();
                    box2.Pop();
                }
                else
                {
                    box1.Enqueue(box2.Pop());
                }
            }

            int lootSum = claimed.Sum();
            if (lootSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootSum}");
            }
        }
    }
}
