using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string directoryToZip = $"..{separator}..{separator}..{separator}..{separator}Resources{separator}TestFolder";
            string archivePath = $"..{separator}..{separator}..{separator}..{separator}Resources{separator}testArchive.zip";

            ZipFile.CreateFromDirectory(directoryToZip, archivePath);

            string directoryToUnzip = $"..{separator}..{separator}..{separator}..{separator}Resources{separator}testArchive-unzipped";
            ZipFile.ExtractToDirectory(archivePath, directoryToUnzip);
        }
    }
}
