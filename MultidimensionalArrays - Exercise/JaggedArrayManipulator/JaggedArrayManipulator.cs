using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    public class JaggedArrayManipulator
    {
        private static double[][] jaggedArray;

        public static void Main()
        {
            // populate
            int rows = int.Parse(Console.ReadLine());

            // N.B. jaggedArray must be double since we have division of integers and the result might not always be integer
            jaggedArray = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                double[] rowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                jaggedArray[i] = rowValues;
            }

            // analyze
            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                int currentRowLength = jaggedArray[i].Length;
                int nextRowLength = jaggedArray[i + 1].Length;

                if (currentRowLength == nextRowLength)
                {
                    for (int j = 0; j < currentRowLength; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < currentRowLength; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }

                    for (int j = 0; j < nextRowLength; j++)
                    {
                        jaggedArray[i + 1][j] /= 2;
                    }
                }
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                switch (cmdArgs[0])
                {
                    case "Add":
                        if (IsValid(row, col))
                        {
                            jaggedArray[row][col] += value;
                        }

                        break;
                    case "Subtract":
                        if (IsValid(row, col))
                        {
                            jaggedArray[row][col] -= value;
                        }

                        break;
                }
            }

            Print(jaggedArray);
        }

        private static void Print(double[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                //for (int j = 0; j < jaggedArray[i].Length; j++)
                //{
                //    Console.Write(jaggedArray[i][j] + " ");
                //}

                //Console.WriteLine();
                Console.WriteLine(string.Join(' ', jaggedArray[i]));
            }
        }

        private static bool IsValid(int row, int col)
        {
            if (row < 0 || row >= jaggedArray.Length)
            {
                return false;
            }

            if (col < 0 || col >= jaggedArray[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
