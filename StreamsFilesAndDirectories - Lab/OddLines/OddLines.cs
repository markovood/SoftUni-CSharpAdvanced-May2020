using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            string pathIn = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}01. Odd Lines{Path.DirectorySeparatorChar}input.txt";
            string pathOut = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}01. Odd Lines{Path.DirectorySeparatorChar}output.txt";

            using (var reader = new StreamReader(pathIn))
            {
                using (var writer = new StreamWriter(pathOut))
                {
                    int lineCounter = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (lineCounter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        lineCounter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}