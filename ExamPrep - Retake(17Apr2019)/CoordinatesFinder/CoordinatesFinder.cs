using System;
using System.Linq;
using System.Text;

namespace CoordinatesFinder
{
    public class CoordinatesFinder
    {
        public static void Main()
        {
            while (true)
            {
                string[] msgArgs = Console.ReadLine().Split(new string[] { "=", "<<" }, StringSplitOptions.RemoveEmptyEntries);
                if (msgArgs[0] == "Last note")
                {
                    break;
                }

                string name = ExtractName(msgArgs[0]);
                if (name == null)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                int length;
                if (!int.TryParse(msgArgs[1], out length))
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                if (msgArgs.Length < 3 || msgArgs[2].Length != length)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                Console.WriteLine($"Coordinates found! {name} -> {msgArgs[2]}");
            }
        }

        private static string ExtractName(string str)
        {
            // "!@Eve?#rest!#=7<<vbnfhfg"
            StringBuilder peakName = new StringBuilder();
            char[] allowedSymbols = new char[] { '!', '@', '#', '$', '?' };

            for (int i = 0; i < str.Length; i++)
            {
                char currentSymbol = str[i];
                if (char.IsLetterOrDigit(currentSymbol))
                {
                    peakName.Append(currentSymbol);
                }
                else if (allowedSymbols.Contains(currentSymbol))
                {
                    continue;
                }
                else
                {
                    return null;
                }
            }

            return peakName.ToString();
        }
    }
}