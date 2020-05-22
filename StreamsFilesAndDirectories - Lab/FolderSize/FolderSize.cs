using System;
using System.Collections.Generic;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        public static void Main()
        {
            // Console.WriteLine("Please, enter a directory to scan:");
            // string directory = Path.GetFullPath(Console.ReadLine());
            string directory = @"..\..\..\..\Resources\06. Folder Size\TestFolder";

            // by using the override constructors can control whether to search just the current directory only
            // or to search all other subdirectories also
            string[] allFiles = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly);

            double totalFilesSizeMiB = 0d;
            // record all files and their sizes
            foreach (var file in allFiles)
            {
                using (var reader = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    double fileSizeMiB = reader.Length / 1_048_576.0;
                    totalFilesSizeMiB += fileSizeMiB;
                }
            }

            string outputPath = @"..\..\..\..\Resources\06. Folder Size\output.txt";
            using (var writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(totalFilesSizeMiB);
            }
        }
    }
}