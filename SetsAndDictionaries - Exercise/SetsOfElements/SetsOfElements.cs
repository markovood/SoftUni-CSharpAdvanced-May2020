using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            int[] lengths = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < lengths.Sum(); i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i >= lengths[0])
                {
                    secondSet.Add(number);
                }
                else
                {
                    firstSet.Add(number);
                }
            }

            List<int> uniqueElements = new List<int>();
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    uniqueElements.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', uniqueElements));
        }
    }
}
