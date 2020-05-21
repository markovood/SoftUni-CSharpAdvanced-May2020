using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            Dictionary<char, int> symbolsAndCount = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if (symbolsAndCount.ContainsKey(symbol))
                {
                    symbolsAndCount[symbol]++;
                }
                else
                {
                    symbolsAndCount.Add(symbol, 1);
                }
            }

            var ordered = symbolsAndCount.OrderBy(s => s.Key);
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
