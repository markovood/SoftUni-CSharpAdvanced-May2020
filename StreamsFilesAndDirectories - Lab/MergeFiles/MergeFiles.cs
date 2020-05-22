using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        public static void Main()
        {
            char dirSeparator = Path.DirectorySeparatorChar;
            string path1In = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}..{dirSeparator}Resources{dirSeparator}04. Merge Files{dirSeparator}FileOne.txt";
            string path2In = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}..{dirSeparator}Resources{dirSeparator}04. Merge Files{dirSeparator}FileTwo.txt";
            string pathOut = $"..{dirSeparator}..{dirSeparator}..{dirSeparator}..{dirSeparator}Resources{dirSeparator}04. Merge Files{dirSeparator}Merged.txt";
            using (var reader1 = new StreamReader(path1In))
            {
                using (var reader2 = new StreamReader(path2In))
                {
                    using (var writer = new StreamWriter(pathOut, true))
                    {
                        string lineFirstFile = reader1.ReadLine();
                        string lineSecondFile = reader2.ReadLine();
                        while (!(lineFirstFile == null && lineSecondFile == null))
                        {
                            if (lineFirstFile != null)
                            {
                                writer.WriteLine(lineFirstFile);
                            }

                            if (lineSecondFile != null)
                            {
                                writer.WriteLine(lineSecondFile);
                            }

                            lineFirstFile = reader1.ReadLine();
                            lineSecondFile = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}