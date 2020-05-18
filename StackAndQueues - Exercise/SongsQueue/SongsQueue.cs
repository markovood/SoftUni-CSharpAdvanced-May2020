using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    public class SongsQueue
    {
        public static void Main()
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songsQueue = new Queue<string>(songs);
            while (songsQueue.Count > 0)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (commandArgs[0])
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        string song = string.Join(' ', commandArgs.Skip(1));
                        if (songsQueue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songsQueue.Enqueue(song); 
                        }

                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
