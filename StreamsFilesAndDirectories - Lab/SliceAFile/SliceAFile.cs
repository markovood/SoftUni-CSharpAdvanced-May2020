using System;
using System.IO;

namespace SliceAFile
{
    public class SliceAFile
    {
        public static void Main()
        {
            Console.WriteLine("Please, enter the full path to file here:");
            string sourceFilePath = Path.GetFullPath(Console.ReadLine());

            int startIndex = sourceFilePath.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            int length = sourceFilePath.Length - startIndex;
            string fileName = sourceFilePath.Substring(startIndex, length);

            Console.WriteLine("Slices will be saved in the '05. Slice File' folder!");
            string destinationDirectory = @"..\..\..\..\Resources\05. Slice File";

            Console.WriteLine($"Please, enter the number of slices you want to cut '{fileName}' into:");
            int parts = int.Parse(Console.ReadLine());

            Slice(sourceFilePath, destinationDirectory, parts);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            Directory.CreateDirectory(destinationDirectory);

            using (var reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string fileExtension = Path.GetExtension(sourceFile);

                long sourceFileBytes = reader.Length;
                long newFilesSize = (long)Math.Ceiling(sourceFileBytes / (double)parts);

                for (int i = 0; i < parts; i++)
                {
                    string currentSlice = $"slice{i + 1}{fileExtension}";
                    string outputPath = Path.Combine(destinationDirectory, currentSlice);

                    byte[] buffer = new byte[newFilesSize];
                    int readBytes = reader.Read(buffer, 0, buffer.Length);

                    using (var writer = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}