using System;

namespace Re_Volt
{
    public class Re_Volt
    {
        private static int playerRow;
        private static int playerCol;
        private static string playerStatus;
        private static char[][] field;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int cmdsCount = int.Parse(Console.ReadLine());

            // fill-up the field
            field = new char[size][];
            for (int i = 0; i < size; i++)
            {
                char[] currentRowValues = Console.ReadLine().ToCharArray();

                field[i] = currentRowValues;
            }

            // find player position
            GetPlayerPosition(field);

            for (int i = 0; i < cmdsCount; i++)
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "up":
                        MoveUp();
                        switch (field[playerRow][playerCol])
                        {
                            case 'F':
                                UpdateFieldUp();
                                PlayerWins();
                                break;
                            case '-':
                                UpdateFieldUp();
                                break;
                            case 'B':
                                UpdateFieldUp();

                                MoveUp();
                                UpdateFieldUp();
                                break;
                            case 'T':
                                MoveDown();
                                break;
                        }

                        break;
                    case "down":
                        MoveDown();
                        switch (field[playerRow][playerCol])
                        {
                            case 'F':
                                UpdateFieldDown();

                                PlayerWins();
                                break;
                            case '-':
                                UpdateFieldDown();

                                break;
                            case 'B':
                                UpdateFieldDown();

                                MoveDown();
                                UpdateFieldDown();


                                break;
                            case 'T':
                                MoveUp();

                                break;
                        }

                        break;
                    case "left":
                        MoveLeft();
                        switch (field[playerRow][playerCol])
                        {
                            case 'F':
                                UpdateFieldLeft();
                                PlayerWins();
                                break;
                            case '-':
                                UpdateFieldLeft();
                                break;
                            case 'B':
                                UpdateFieldLeft();

                                MoveLeft();
                                UpdateFieldLeft();
                                break;
                            case 'T':
                                MoveRight();
                                break;
                        }

                        break;
                    case "right":
                        MoveRight();
                        switch (field[playerRow][playerCol])
                        {
                            case 'F':
                                UpdateFieldRight();
                                PlayerWins();
                                break;
                            case '-':
                                UpdateFieldRight();
                                break;
                            case 'B':
                                UpdateFieldRight();

                                MoveRight();
                                UpdateFieldRight();
                                break;
                            case 'T':
                                MoveLeft();
                                break;
                        }

                        break;
                }
            }

            // print
            playerStatus = "Player lost!";
            Console.WriteLine(playerStatus);
            PrintField();
        }

        private static void GetPlayerPosition(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                        return;
                    }
                }
            }
        }

        private static void MoveUp()
        {
            playerRow--;
            if (playerRow < 0)
            {
                playerRow = field.Length - 1;
            }
        }

        private static void MoveDown()
        {
            playerRow++;
            if (playerRow >= field.Length)
            {
                playerRow = 0;
            }
        }

        private static void MoveLeft()
        {
            playerCol--;
            if (playerCol < 0)
            {
                playerCol = field[0].Length - 1;
            }
        }

        private static void MoveRight()
        {
            playerCol++;
            if (playerCol >= field[0].Length)
            {
                playerCol = 0;
            }
        }

        private static void UpdateFieldUp()
        {
            if (playerRow + 1 >= field.Length) // the case when index is changed because of exiting the field
            {
                if (field[0][playerCol] != 'B')
                {
                    field[0][playerCol] = '-';
                }
            }
            else
            {
                if (field[playerRow + 1][playerCol] != 'B')
                {
                    field[playerRow + 1][playerCol] = '-';
                }
            }

            if (field[playerRow][playerCol] == 'F')
            {
                field[playerRow][playerCol] = 'f';
                PlayerWins();
            }
            else if (field[playerRow][playerCol] != 'B')
            {
                field[playerRow][playerCol] = 'f';
            }
        }

        private static void UpdateFieldDown()
        {
            if (playerRow - 1 < 0) // the case when index is changed because of exiting the field
            {
                if (field[field.Length - 1][playerCol] != 'B')
                {
                    field[field.Length - 1][playerCol] = '-';
                }
            }
            else
            {
                if (field[playerRow - 1][playerCol] != 'B')
                {
                    field[playerRow - 1][playerCol] = '-';
                }
            }

            if (field[playerRow][playerCol] == 'F')
            {
                field[playerRow][playerCol] = 'f';
                PlayerWins();
            }
            else if (field[playerRow][playerCol] != 'B')
            {
                field[playerRow][playerCol] = 'f';
            }
        }

        private static void UpdateFieldLeft()
        {
            if (playerCol + 1 >= field[0].Length) // the case when index is changed because of exiting the field
            {
                if (field[playerRow][0] != 'B')
                {
                    field[playerRow][0] = '-';
                }
            }
            else
            {
                if (field[playerRow][playerCol + 1] != 'B')
                {
                    field[playerRow][playerCol + 1] = '-';
                }
            }

            if (field[playerRow][playerCol] == 'F')
            {
                field[playerRow][playerCol] = 'f';
                PlayerWins();
            }
            else if (field[playerRow][playerCol] != 'B')
            {
                field[playerRow][playerCol] = 'f';
            }
        }

        private static void UpdateFieldRight()
        {
            if (playerCol - 1 < 0) // the case when index is changed because of exiting the field
            {
                if (field[playerRow][field[0].Length - 1] != 'B')
                {
                    field[playerRow][field[0].Length - 1] = '-';
                }
            }
            else
            {
                if (field[playerRow][playerCol - 1] != 'B')
                {
                    field[playerRow][playerCol - 1] = '-';
                }
            }

            if (field[playerRow][playerCol] == 'F')
            {
                field[playerRow][playerCol] = 'f';
                PlayerWins();
            }
            else if (field[playerRow][playerCol] != 'B')
            {
                field[playerRow][playerCol] = 'f';
            }
        }

        private static void PlayerWins()
        {
            playerStatus = "Player won!";

            Console.WriteLine(playerStatus);
            PrintField();
            Environment.Exit(0);
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