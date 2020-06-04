using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string inputFile = "text.txt";
            string outputFile = "lineNumbersOutput.txt";
            string resourcePath = $"..{separator}..{separator}..{separator}..{separator}Resources";

            string pathIn = Path.Combine(resourcePath, inputFile);
            string pathOut = Path.Combine(resourcePath, outputFile);

            List<string> resultLines = new List<string>();
            using (var reader = File.OpenText(pathIn))
            {
                int lineNumber = 1;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    resultLines.Add(CountLettersAndPunctuations(lineNumber, line));
                    lineNumber++;
                }
            }

            File.WriteAllLines(pathOut, resultLines);
        }

        private static string CountLettersAndPunctuations(int lineNumber, string line)
        {
            StringBuilder newline = new StringBuilder();
            newline.Append($"Line {lineNumber}: ");
            int letters = 0;
            int punctuationMarks = 0;
            foreach (var symbol in line)
            {
                if (char.IsLetter(symbol))
                {
                    letters++;
                }
                else if (char.IsPunctuation(symbol))
                {
                    punctuationMarks++;
                }
            }

            newline.Append(line);
            newline.Append($" ({letters})({punctuationMarks})");

            return newline.ToString();
        }
    }
}