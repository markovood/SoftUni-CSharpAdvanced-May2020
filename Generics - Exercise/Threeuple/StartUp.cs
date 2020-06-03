using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            // {first name} {last name} {address} {town}
            string[] line1Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string town = string.Join(' ', line1Args.Skip(3));
            var tuple = new Threeuple<string, string, string>($"{line1Args[0]} {line1Args[1]}", line1Args[2], town);

            Console.WriteLine(tuple);

            // {name} {liters of beer} {drunk or not}
            string[] line2Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = string.Join(' ', line2Args.SkipLast(2));
            int liters = int.Parse(line2Args[line2Args.Length - 2]);
            bool isDrunk = line2Args[line2Args.Length - 1] == "drunk" ? true : false;
            var otherTuple = new Threeuple<string, int, bool>(name, liters, isDrunk);

            Console.WriteLine(otherTuple);

            // {name} {account balance} {bank name}
            string[] line3Args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            name = string.Join(' ', line3Args.SkipLast(2));
            double balance = double.Parse(line3Args[line3Args.Length - 2]);
            string bank = line3Args.Last();
            var anotherTuple = new Threeuple<string, double, string>(name, balance, bank);

            Console.WriteLine(anotherTuple);
        }
    }
}