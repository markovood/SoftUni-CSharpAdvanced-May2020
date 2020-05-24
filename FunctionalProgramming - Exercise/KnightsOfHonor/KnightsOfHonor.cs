using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            string[] collection = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // assign the delegate all the methods that have to be executed
            Action<string[]> action;
            action = AppendSir;
            action += PrintOnConsole;

            // execute the delegate
            action(collection);
        }

        private static void AppendSir(string[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                collection[i] = collection[i].Insert(0, "Sir ");
            }
        }

        private static void PrintOnConsole(string[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
