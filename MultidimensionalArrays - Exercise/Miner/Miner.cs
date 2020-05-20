using System;
using System.Linq;

namespace Miner
{
    public class Miner
    {
        private static char[][] field;
        private static int minerRow;
        private static int minerCol;
        private static int coalsCollected;
        private static int totalCoals;

        public static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());// N.B. what happens when fieldSize == 0

            string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // populate the field
            field = new char[fieldSize][];
            for (int i = 0; i < fieldSize; i++)
            {
                char[] rowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                field[i] = rowValues;

                totalCoals += rowValues.Where(symbol => symbol == 'c').Count();

                int index = Array.IndexOf(rowValues, 's');
                if (index != -1)
                {
                    minerRow = i;
                    minerCol = index;
                }
            }

            // run commands
            foreach (var cmd in cmdArgs)
            {
                ExecuteCmd(cmd);
            }

            Console.WriteLine($"{totalCoals - coalsCollected} coals left. ({minerRow}, {minerCol})");
        }

        private static void ExecuteCmd(string cmd)
        {
            switch (cmd)
            {
                case "left":
                    if (IsInside(minerRow, minerCol - 1))
                    {
                        minerCol--;
                        ProcessMove();
                    }

                    break;
                case "right":
                    if (IsInside(minerRow, minerCol + 1))
                    {
                        minerCol++;
                        ProcessMove();
                    }

                    break;
                case "up":
                    if (IsInside(minerRow - 1, minerCol))
                    {
                        minerRow--;
                        ProcessMove();
                    }

                    break;
                case "down":
                    if (IsInside(minerRow + 1, minerCol))
                    {
                        minerRow++;
                        ProcessMove();
                    }

                    break;
            }
        }

        private static void ProcessMove()
        {
            if (field[minerRow][minerCol] == 'c')
            {
                coalsCollected++;
                field[minerRow][minerCol] = '*';
                if (coalsCollected == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    Environment.Exit(0);
                }
            }
            else if (field[minerRow][minerCol] == 'e')
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                Environment.Exit(0);
            }
        }

        private static bool IsInside(int row, int col)
        {
            if (row < 0 || row >= field.Length)
            {
                return false;
            }

            if (col < 0 || col >= field[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
