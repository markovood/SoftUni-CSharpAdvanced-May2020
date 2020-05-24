using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers.Reverse();
            numbers.RemoveAll(n => n % divisor == 0);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
