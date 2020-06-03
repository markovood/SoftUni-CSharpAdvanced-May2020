using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            // {first name} {last name} {address}
            string[] line1Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var tuple = new Tuple<string, string>($"{line1Args[0]} {line1Args[1]}", line1Args[2]);
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");

            // {name} {liters of beer}
            string[] line2Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var otherTuple = new Tuple<string, int>(string.Join(' ', line2Args.SkipLast(1)), int.Parse(line2Args.Last()));
            Console.WriteLine($"{otherTuple.Item1} -> {otherTuple.Item2}");

            // {integer} {double}
            string[] line3Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var anotherTuple = new Tuple<int, double>(int.Parse(line3Args[0]), double.Parse(line3Args[1]));
            Console.WriteLine($"{anotherTuple.Item1} -> {anotherTuple.Item2}");
        }
    }
}
