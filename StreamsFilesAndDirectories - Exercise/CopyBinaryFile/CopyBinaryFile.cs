using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string fileToCopy = "pic.jpg";
            string fileDirectory = $"..{separator}..{separator}..{separator}..{separator}Resources";

            string fileToCopyPath = Path.Combine(fileDirectory, fileToCopy);
            string copiedFilePath = Path.Combine(fileDirectory, "pic(copy).jpg");

            CopyFile(fileToCopyPath, copiedFilePath);
        }

        private static void CopyFile(string pathToFile, string newFilePath)
        {
            using (FileStream reader = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = reader.Read(buffer, 0, buffer.Length);

                    while (readBytes != 0)
                    {
                        writer.Write(buffer, 0, readBytes);

                        readBytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
