using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    public class EvenTimes
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersAndCount = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbersAndCount.ContainsKey(number))
                {
                    numbersAndCount[number]++;
                }
                else
                {
                    numbersAndCount.Add(number, 1);
                }
            }

            Console.WriteLine(numbersAndCount
                                .Where(n => n.Value % 2 == 0)
                                .First()
                                .Key);
        }
    }
}
