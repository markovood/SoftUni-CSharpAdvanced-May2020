using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            IEnumerable<int> numbers = Enumerable.Range(bounds[0], bounds[1] - bounds[0] + 1);

            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "odd":
                    // Console.WriteLine(string.Join(' ', FilterNumbers(numbers, x => x % 2 != 0)));
                    Console.WriteLine(string.Join(' ', FilterNumbers(numbers, OddFilter)));
                    break;
                case "even":
                    // Console.WriteLine(string.Join(' ', FilterNumbers(numbers, x => x % 2 == 0)));
                    Console.WriteLine(string.Join(' ', FilterNumbers(numbers, EvenFilter)));
                    break;
            }
        }

        private static List<int> FilterNumbers(IEnumerable<int> numbers, Predicate<int> filter)
        {
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static bool OddFilter(int number)
        {
            if (number % 2 != 0)
            {
                return true;
            }

            return false;
        }

        private static bool EvenFilter(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
