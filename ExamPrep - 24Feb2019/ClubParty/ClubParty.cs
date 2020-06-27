using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class ClubParty
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<char> halls = new Queue<char>();
            List<int> people = new List<int>();

            for (int i = inputArgs.Length - 1; i >= 0; i--)
            {
                string currentItem = inputArgs[i];
                if (char.TryParse(currentItem, out char result))
                {
                    if (char.IsLetter(result))
                    {
                        halls.Enqueue(result);
                    } 
                }

                if (int.TryParse(currentItem, out int parsed))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (people.Sum() + parsed <= maxCapacity)
                    {
                        people.Add(parsed);
                    }
                    else
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", people)}");
                        people.Clear();
                        if (halls.Count > 0)
                        {
                            people.Add(parsed);
                        }
                    }
                }
            }
        }
    }
}