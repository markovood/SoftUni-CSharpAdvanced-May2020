using System;
using System.Linq;

namespace MatrixShuffling
{
    public class MatrixShuffling
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowValues[j];
                }
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] != "swap" ||
                    (cmdArgs.Length < 5 || cmdArgs.Length > 5))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);

                if (!ValidateRow(row1, matrix) && 
                    !ValidateCol(col1,matrix) &&
                    !ValidateRow(row2, matrix) &&
                    !ValidateCol(col2, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Swap(row1, col1, row2, col2, matrix);
                Print(matrix);
            }
        }

        private static void Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        private static bool ValidateRow(int row, string[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateCol(int col, string[,] matrix)
        {
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
