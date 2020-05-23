using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string testDirectory = $"..{separator}..{separator}..{separator}..{separator}Resources{separator}TestFolder";

            // create directory with files and sizes as in the picture in the task assignment for debugging purposes
            GenerateTestDirectory(testDirectory);

            var extensionsAndFiles = new Dictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(testDirectory);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                if (extensionsAndFiles.ContainsKey(extension))
                {
                    if (!extensionsAndFiles[extension].Contains(fileInfo))
                    {
                        extensionsAndFiles[extension].Add(fileInfo);
                    }
                }
                else
                {
                    extensionsAndFiles.Add(extension, new List<FileInfo>() { fileInfo });
                }
            }

            var orderedByCountAndName = extensionsAndFiles
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportFile = "report.txt";
            string pathToReport = Path.Combine(desktopPath, reportFile);
            using (var writer = new StreamWriter(pathToReport, false))
            {
                foreach (var extension in orderedByCountAndName.Keys)
                {
                    writer.WriteLine(extension);
                    foreach (var file in orderedByCountAndName[extension].OrderBy(f => f.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {file.Length / 1000d}kb");
                    }
                }
            }
        }

        private static void GenerateTestDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}bin");
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}obj");
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}Properties");

            string fileName = "Mecanismo.cs";
            string fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(994);
            }

            fileName = "Program.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(1108);
            }

            fileName = "Nashmat.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(3967);
            }

            fileName = "Wedding.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(23787);
            }

            fileName = "Program - Copy.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(35679);
            }

            fileName = "Salimur.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(588657);
            }

            fileName = "backup.txt";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(28);
            }

            fileName = "log.txt";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(6720);
            }

            fileName = "script.asm";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(28);
            }

            fileName = "App.config";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(187);
            }

            fileName = "01. Writing-To-Files.csproj";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(2570);
            }

            fileName = "controller.js";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(1635143);
            }

            fileName = "model.php";
            fileToCreate = Path.Combine(directoryPath, fileName);

            using (var fs = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.SetLength(0);
            }
        }
    }
}