using System;
using System.Linq;

namespace SnakeMoves
{
    public class SnakeMoves
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string snake = Console.ReadLine();

            char[,] field = new char[rows, cols];
            int snakeCharIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    // go right
                    for (int j = 0; j < cols; j++)
                    {
                        if (snakeCharIndex >= snake.Length)
                        {
                            snakeCharIndex = 0;
                        }

                        field[i, j] = snake[snakeCharIndex];
                        snakeCharIndex++;
                    }
                }
                else
                {
                    // go left
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        if (snakeCharIndex >= snake.Length)
                        {
                            snakeCharIndex = 0;
                        }

                        field[i, j] = snake[snakeCharIndex];
                        snakeCharIndex++;
                    }
                }
            }

            Print(field);
        }

        private static void Print(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
