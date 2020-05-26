using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            int end = int.Parse(Console.ReadLine());
            IEnumerable<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int[] range = Enumerable.Range(1, end).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();
            foreach (var divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            // print all numbers from the range which are divisible to all divisors together
            for (int i = 0; i < range.Length; i++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(range[i]))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write("{0} ", range[i]);
                }
            }
        }
    }
}