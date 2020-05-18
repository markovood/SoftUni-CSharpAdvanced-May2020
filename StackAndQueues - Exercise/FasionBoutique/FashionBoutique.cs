using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    public class FashionBoutique
    {
        public static void Main()
        {
            int[] clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothes);
            int sum = 0;
            int rackCounter = 0;
            while (box.Count != 0)
            {
                sum += box.Peek();
                if (sum < rackCapacity)
                {
                    box.Pop();
                }
                else if (sum == rackCapacity && box.Count > 0)
                {
                    rackCounter++;
                    box.Pop();
                    sum = 0;
                }
                else
                {
                    rackCounter++;
                    sum = 0;
                }
            }

            if (sum != 0)
            {
                rackCounter++;
            }
            Console.WriteLine(rackCounter);
        }
    }
}