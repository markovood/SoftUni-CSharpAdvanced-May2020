using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class Supermarket
    {
        public static void Main()
        {
            Queue<string> people = new Queue<string>();
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (name == "Paid")
                {
                    while (people.Count != 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(name);
                }
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}