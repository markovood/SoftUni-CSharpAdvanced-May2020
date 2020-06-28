using System;

namespace Snake
{
    public class StartUp
    {
        private static char[][] field;

        private static int snakeRow;
        private static int snakeCol;

        private static int B1Row = -1;
        private static int B1Col = -1;

        private static int B2Row = -1;
        private static int B2Col = -1;

        private static int foodQuantity = 0;

        private static bool isDead = false;


        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            field = new char[N][];
            for (int i = 0; i < N; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                field[i] = rowValues;

                int indexS = Array.IndexOf(rowValues, 'S');
                if (indexS >= 0)
                {
                    snakeRow = i;
                    snakeCol = indexS;
                }

                int indexB = Array.IndexOf(rowValues, 'B');
                if (indexB >= 0)
                {
                    if (B1Row >= 0)
                    {
                        B2Row = i;
                        B2Col = indexB;
                    }
                    else
                    {
                        B1Row = i;
                        B1Col = indexB;
                    }
                }
            }

            // read cmds
            while (true)
            {
                if (isDead)
                {
                    break;
                }

                if (foodQuantity == 10)
                {
                    break;
                }

                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "up":
                        snakeRow--;
                        if (IsOutOfField())
                        {
                            field[snakeRow + 1][snakeCol] = '.';
                            isDead = true;
                            break;
                        }

                        switch (field[snakeRow][snakeCol])
                        {
                            case '*':
                                foodQuantity++;
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow + 1][snakeCol] = '.';
                                break;
                            case '-':
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow + 1][snakeCol] = '.';
                                break;
                            case 'B':
                                field[snakeRow + 1][snakeCol] = '.';
                                if (snakeRow == B1Row && snakeCol == B1Col)
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B2Row;
                                    snakeCol = B2Col;
                                }
                                else
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B1Row;
                                    snakeCol = B1Col;
                                }

                                field[snakeRow][snakeCol] = 'S';

                                break;
                        }

                        break;
                    case "down":
                        snakeRow++;
                        if (IsOutOfField())
                        {
                            field[snakeRow - 1][snakeCol] = '.';
                            isDead = true;
                            break;
                        }

                        switch (field[snakeRow][snakeCol])
                        {
                            case '*':
                                foodQuantity++;
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow - 1][snakeCol] = '.';
                                break;
                            case '-':
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow - 1][snakeCol] = '.';
                                break;
                            case 'B':
                                field[snakeRow - 1][snakeCol] = '.';
                                if (snakeRow == B1Row && snakeCol == B1Col)
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B2Row;
                                    snakeCol = B2Col;
                                }
                                else
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B1Row;
                                    snakeCol = B1Col;
                                }

                                field[snakeRow][snakeCol] = 'S';

                                break;
                        }

                        break;
                    case "left":
                        snakeCol--;
                        if (IsOutOfField())
                        {
                            field[snakeRow][snakeCol + 1] = '.';
                            isDead = true;
                            break;
                        }

                        switch (field[snakeRow][snakeCol])
                        {
                            case '*':
                                foodQuantity++;
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow][snakeCol + 1] = '.';
                                break;
                            case '-':
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow][snakeCol + 1] = '.';
                                break;
                            case 'B':
                                field[snakeRow][snakeCol + 1] = '.';
                                if (snakeRow == B1Row && snakeCol == B1Col)
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B2Row;
                                    snakeCol = B2Col;
                                }
                                else
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B1Row;
                                    snakeCol = B1Col;
                                }

                                field[snakeRow][snakeCol] = 'S';

                                break;
                        }

                        break;
                    case "right":
                        snakeCol++;
                        if (IsOutOfField())
                        {
                            field[snakeRow][snakeCol - 1] = '.';
                            isDead = true;
                            break;
                        }

                        switch (field[snakeRow][snakeCol])
                        {
                            case '*':
                                foodQuantity++;
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow][snakeCol - 1] = '.';
                                break;
                            case '-':
                                field[snakeRow][snakeCol] = 'S';
                                field[snakeRow][snakeCol - 1] = '.';
                                break;
                            case 'B':
                                field[snakeRow][snakeCol - 1] = '.';
                                if (snakeRow == B1Row && snakeCol == B1Col)
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B2Row;
                                    snakeCol = B2Col;
                                }
                                else
                                {
                                    field[snakeRow][snakeCol] = '.';
                                    snakeRow = B1Row;
                                    snakeCol = B1Col;
                                }

                                field[snakeRow][snakeCol] = 'S';

                                break;
                        }

                        break;
                }
            }

            if (isDead)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintField();
        }

        private static bool IsOutOfField()
        {
            if (snakeRow < 0 || snakeRow >= field.Length)
            {
                return true;
            }

            if (snakeCol < 0 || snakeCol >= field[0].Length)
            {
                return true;
            }

            return false;
        }

        private static void PrintField()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}