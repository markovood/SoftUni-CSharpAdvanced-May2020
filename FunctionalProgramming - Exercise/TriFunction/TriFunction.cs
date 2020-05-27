using System;
using System.Linq;

namespace TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isSumGreaterOrEqualFunc = (name, sum) => name.Sum(x => x) >= sum;

            Func<string[], Func<string, int, bool>, string> getFirstName = (arr, func) =>
            {
                foreach (var name in arr)
                {
                    if (func(name, sum))
                    {
                        return name;
                    }
                }

                return null;
            };

            Console.WriteLine(getFirstName(names, isSumGreaterOrEqualFunc));
        }
    }
}
