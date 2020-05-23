using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            char separator = Path.DirectorySeparatorChar;
            string textInput = "text.txt";
            string wordsInput = "words.txt";
            string actualResultOutput = "actualResultOutput.txt";
            string expectedResultOutput = "expectedResultOutput.txt";

            string resourcePath = $"..{separator}..{separator}..{separator}..{separator}Resources";

            string pathText = Path.Combine(resourcePath, textInput);
            string pathWords = Path.Combine(resourcePath, wordsInput);
            string pathActual = Path.Combine(resourcePath, actualResultOutput);
            string pathExpected = Path.Combine(resourcePath, expectedResultOutput);

            string[] words = File.ReadAllLines(pathWords);
            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();
            using (var reader = File.OpenText(pathText))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    foreach (var word in words)
                    {
                        int count = CountWord(word, line);

                        if (wordsAndCount.ContainsKey(word))
                        {
                            wordsAndCount[word] += count;
                        }
                        else
                        {
                            wordsAndCount.Add(word, count);
                        }
                    }
                }
            }

            List<string> allLines = GetLines(wordsAndCount);
            File.WriteAllLines(pathActual, allLines);

            var orderedByFrequencyDescending = wordsAndCount
                .OrderByDescending(w => w.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            allLines = GetLines(orderedByFrequencyDescending);
            File.WriteAllLines(pathExpected, allLines);
        }

        private static List<string> GetLines(Dictionary<string, int> wordsAndCount)
        {
            List<string> allLines = new List<string>();
            foreach (var wordAndCount in wordsAndCount)
            {
                string currentLine = $"{wordAndCount.Key} - {wordAndCount.Value}";
                allLines.Add(currentLine);
            }

            return allLines;
        }

        private static int CountWord(string word, string line)
        {
            string[] lineWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var lineWord in lineWords)
            {
                if (lineWord.Trim('-', ',', '.', '!', '?').ToLower() == word.ToLower())
                {
                    count++;
                }
            }

            return count;
        }
    }
}
