using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string file = "text.txt";
            string resourcePath = @$"..{separator}..{separator}..{separator}..{separator}Resources";

            string pathIn = Path.Combine(resourcePath, file);
            using (var reader = new StreamReader(pathIn))
            {
                int lineCounter = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (lineCounter % 2 == 0)
                    {
                        // Replace
                        line = Replace(line, new char[] { '-', ',', '.', '!', '?' }, '@');

                        // Reverse
                        line = Reverse(line);

                        Console.WriteLine(line);
                    }

                    lineCounter++;
                }
            }
        }

        private static string Replace(string line, char[] forbidenSymbols, char newSymbol)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                if (forbidenSymbols.Contains(line[i]))
                {
                    result.Append('@');
                }
                else
                {
                    result.Append(line[i]);
                }
            }

            return result.ToString();
        }

        private static string Reverse(string line)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            return string.Join(' ', words.Reverse());
        }
    }
}
