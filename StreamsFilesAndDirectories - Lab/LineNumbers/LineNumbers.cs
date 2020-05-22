using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            char dirSeparator = Path.DirectorySeparatorChar;
            string inputFileName = "input.txt";
            string outputFileName = "output.txt";
            string pathIn = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}..{dirSeparator}Resources{dirSeparator}02. Line Numbers{dirSeparator}{inputFileName}";
            string pathOut = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}..{dirSeparator}Resources{dirSeparator}02. Line Numbers{dirSeparator}{outputFileName}";

            using (var reader = new StreamReader(pathIn))
            {
                using (var writer = new StreamWriter(pathOut))
                {
                    int lineNumber = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{lineNumber}: " + line);
                        lineNumber++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}