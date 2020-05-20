using System;
using System.Linq;

namespace Bombs
{
    public class Bombs
    {
        private static int[][] matrix;

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            matrix = new int[N][];
            for (int i = 0; i < N; i++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = rowValues;
            }

            string[] bombsCoords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombsCoords)
            {
                int[] bombRC = bomb
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                ProcessBomb(bombRC);
            }

            int aliveCellsCount = 0;
            long sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > 0)
                    {
                        aliveCellsCount++;
                        sum += matrix[i][j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {sum}");
            Print(matrix);
        }

        private static void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }

        private static void ProcessBomb(int[] bombRC)
        {
            int bombRow = bombRC[0];
            int bombCol = bombRC[1];
            int bombValue = matrix[bombRow][bombCol];

            if (bombValue > 0)
            {
                // up
                AttackCell(bombRow - 1, bombCol, bombValue);
                // up-right
                AttackCell(bombRow - 1, bombCol + 1, bombValue);
                // right
                AttackCell(bombRow, bombCol + 1, bombValue);
                // down-right
                AttackCell(bombRow + 1, bombCol + 1, bombValue);
                // down
                AttackCell(bombRow + 1, bombCol, bombValue);
                // down-left
                AttackCell(bombRow + 1, bombCol - 1, bombValue);
                // left
                AttackCell(bombRow, bombCol - 1, bombValue);
                // up-left
                AttackCell(bombRow - 1, bombCol - 1, bombValue);
                // explode bomb itself
                AttackCell(bombRow, bombCol, bombValue); 
            }
        }

        private static void AttackCell(int row, int col, int value)
        {
            if (IsValidCoord(row, col))
            {
                if (matrix[row][col] > 0)
                {
                    matrix[row][col] -= value;
                }
            }
        }

        private static bool IsValidCoord(int row, int col)
        {
            if (row < 0 || row >= matrix.Length)
            {
                return false;
            }

            if (col < 0 || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
