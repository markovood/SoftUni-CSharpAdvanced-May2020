using System;
using System.Collections.Generic;
using System.Linq;

namespace CatapultAttack
{
    public class CatapultAttack
    {
        public static void Main()
        {
            int pilesCount = int.Parse(Console.ReadLine());
            int[] wallsValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> walls = new Queue<int>(wallsValues);

            int currentWall = walls.Dequeue();
            for (int i = 1; i <= pilesCount; i++)
            {
                Stack<int> pile = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (i % 3 == 0)
                {
                    walls.Enqueue(int.Parse(Console.ReadLine()));
                }

                // Attack
                while (true)
                {
                    if (pile.Count == 0)
                    {
                        break;
                    }

                    if (currentWall <= 0)
                    {
                        if (!walls.TryDequeue(out currentWall))
                        {
                            Console.WriteLine($"Rocks left: {string.Join(", ", pile)}");
                            return;
                        }
                    }

                    int rock = pile.Pop();
                    if (rock > currentWall)
                    {
                        rock -= currentWall;
                        currentWall = 0;
                        if (rock > 0)
                        {
                            pile.Push(rock);
                        }
                    }
                    else if (currentWall > rock)
                    {
                        currentWall -= rock;
                    }
                    else
                    {
                        currentWall = 0;
                    }
                }
            }

            string wallsLeft = walls.Count == 0 && currentWall > 0 ? $"{currentWall}" :
                                    walls.Count > 0 && currentWall > 0 ? $"{currentWall}, {string.Join(", ", walls)}" :
                                        walls.Count > 0 && currentWall == 0 ? $"{string.Join(", ", walls)}" : "";
            Console.WriteLine($"Walls left: {wallsLeft}");
        }
    }
}