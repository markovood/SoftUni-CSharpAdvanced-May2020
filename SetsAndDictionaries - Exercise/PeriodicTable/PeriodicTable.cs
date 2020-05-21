using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in line)
                {
                    elements.Add(item);
                }
            }

            var ordered = elements.OrderBy(e => e);

            Console.WriteLine(string.Join(' ', ordered));

        }
    }
}
