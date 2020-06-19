using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    public class DatingApp
    {
        public static void Main()
        {
            int[] malesInts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> males = new Stack<int>(malesInts);

            int[] femalesInts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> females = new Queue<int>(femalesInts);

            int matches = 0;
            while (true)
            {
                if (males.Count == 0 || females.Count == 0)
                {
                    break;
                }

                int male = males.Peek();
                int female = females.Peek();
                if (male <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (female <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (male % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }

                if (female % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if (male == female)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine("Males left: " + string.Join(", ", males));
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine("Females left: " + string.Join(", ", females));
            }
        }
    }
}
