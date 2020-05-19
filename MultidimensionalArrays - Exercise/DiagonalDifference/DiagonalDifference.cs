using System;
using System.Linq;

namespace DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = rowValues[j];
                }
            }

            int primaryDiagonalSum = 0;
            for (int i = 0; i < N; i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            int secondaryDiagonalSum = 0;
            for (int i = 0, j = matrix.GetLength(1) - 1; i < matrix.GetLength(0); i++, j--)
            {
                secondaryDiagonalSum += matrix[i, j];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
