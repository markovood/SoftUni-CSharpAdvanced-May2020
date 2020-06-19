using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm
{
    public class BookWorm
    {
        private static Stack<char> worm;
        private static int playerRow;
        private static int playerCol;
        private static char[][] field;

        public static void Main()
        {
            string initialStr = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());

            worm = new Stack<char>(initialStr);
            field = new char[N][];

            for (int i = 0; i < N; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                int indexCol = Array.IndexOf(rowValues, 'P');
                if (indexCol >= 0)
                {
                    playerRow = i;
                    playerCol = indexCol;
                }

                field[i] = rowValues;
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end")
                {
                    break;
                }

                switch (cmd)
                {
                    case "up":
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow++;
                            PunishWorm();
                            continue;
                        }

                        if (char.IsLetter(field[playerRow][playerCol]))
                        {
                            worm.Push(field[playerRow][playerCol]);
                        }

                        UpdateFieldUp();
                        break;
                    case "down":
                        playerRow++;
                        if (playerRow >= field.Length)
                        {
                            playerRow--;
                            PunishWorm();
                            continue;
                        }

                        if (char.IsLetter(field[playerRow][playerCol]))
                        {
                            worm.Push(field[playerRow][playerCol]);
                        }

                        UpdateFieldDown();
                        break;
                    case "left":
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol++;
                            PunishWorm();
                            continue;
                        }

                        if (char.IsLetter(field[playerRow][playerCol]))
                        {
                            worm.Push(field[playerRow][playerCol]);
                        }

                        UpdateFieldLeft();
                        break;
                    case "right":
                        playerCol++;
                        if (playerCol >= field[0].Length)
                        {
                            playerCol--;
                            PunishWorm();
                            continue;
                        }

                        if (char.IsLetter(field[playerRow][playerCol]))
                        {
                            worm.Push(field[playerRow][playerCol]);
                        }

                        UpdateFieldRight();
                        break;
                }
            }

            PrintWorm();
            PrintField();
        }

        private static void PunishWorm()
        {
            if (worm.Count > 0)
            {
                worm.Pop();
            }
        }

        private static void UpdateFieldRight()
        {
            field[playerRow][playerCol] = 'P';
            field[playerRow][playerCol - 1] = '-';
        }

        private static void UpdateFieldLeft()
        {
            field[playerRow][playerCol] = 'P';
            field[playerRow][playerCol + 1] = '-';
        }

        private static void UpdateFieldDown()
        {
            field[playerRow][playerCol] = 'P';
            field[playerRow - 1][playerCol] = '-';
        }

        private static void UpdateFieldUp()
        {
            field[playerRow][playerCol] = 'P';
            field[playerRow + 1][playerCol] = '-';
        }

        private static void PrintWorm()
        {
            Console.WriteLine(string.Join("", worm.Reverse()));
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