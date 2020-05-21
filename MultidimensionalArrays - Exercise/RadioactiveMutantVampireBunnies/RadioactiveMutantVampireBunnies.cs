using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    public class RadioactiveMutantVampireBunnies
    {
        private static char[][] lair;
        private static int playerRow;
        private static int playerCol;
        private static bool isDead = false;
        private static bool hasWon = false;

        public static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            // populate the matrix
            lair = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                lair[i] = rowValues;

                int index = Array.IndexOf(rowValues, 'P');
                if (index != -1)
                {
                    playerRow = i;
                    playerCol = index;
                }
            }

            char[] cmds = Console.ReadLine().ToArray();

            // run commands
            foreach (var cmd in cmds)
            {
                switch (cmd)
                {
                    case 'L':
                        playerCol--;
                        if (!IsValid(playerRow, playerCol))
                        {
                            // wins
                            hasWon = true;
                            lair[playerRow][playerCol + 1] = '.';
                            playerCol++;
                        }
                        else if (lair[playerRow][playerCol] == '.')
                        {
                            // update position
                            lair[playerRow][playerCol] = 'P';
                            lair[playerRow][playerCol + 1] = '.';
                        }
                        else if (lair[playerRow][playerCol] == 'B')
                        {
                            // dies
                            isDead = true;
                            lair[playerRow][playerCol + 1] = '.';
                        }

                        break;
                    case 'R':
                        playerCol++;
                        if (!IsValid(playerRow, playerCol))
                        {
                            // wins
                            hasWon = true;
                            lair[playerRow][playerCol - 1] = '.';
                            playerCol--;
                        }
                        else if (lair[playerRow][playerCol] == '.')
                        {
                            // update position
                            lair[playerRow][playerCol] = 'P';
                            lair[playerRow][playerCol - 1] = '.';
                        }
                        else if (lair[playerRow][playerCol] == 'B')
                        {
                            // dies
                            isDead = true;
                            lair[playerRow][playerCol - 1] = '.';
                        }

                        break;
                    case 'U':
                        playerRow--;
                        if (!IsValid(playerRow, playerCol))
                        {
                            // wins
                            hasWon = true;
                            lair[playerRow + 1][playerCol] = '.';
                            playerRow++;
                        }
                        else if (lair[playerRow][playerCol] == '.')
                        {
                            // update position
                            lair[playerRow][playerCol] = 'P';
                            lair[playerRow + 1][playerCol] = '.';
                        }
                        else if (lair[playerRow][playerCol] == 'B')
                        {
                            // dies
                            isDead = true;
                            lair[playerRow + 1][playerCol] = '.';
                        }

                        break;
                    case 'D':
                        playerRow++;
                        if (!IsValid(playerRow, playerCol))
                        {
                            // wins
                            hasWon = true;
                            lair[playerRow - 1][playerCol] = '.';
                            playerRow--;
                        }
                        else if (lair[playerRow][playerCol] == '.')
                        {
                            // update position
                            lair[playerRow][playerCol] = 'P';
                            lair[playerRow - 1][playerCol] = '.';
                        }
                        else if (lair[playerRow][playerCol] == 'B')
                        {
                            // dies
                            isDead = true;
                            lair[playerRow - 1][playerCol] = '.';
                        }

                        break;
                }

                // spread bunnies
                List<int[]> bunnies = GetCurrentBunniesPosition();
                foreach (var bunny in bunnies)
                {
                    SpreadBunny(bunny);
                }

                if (isDead || hasWon)
                {
                    break;
                }
            }

            Print(lair);
            if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        private static void SpreadBunny(int[] bunny)
        {
            int bunnyRow = bunny[0];
            int bunnyCol = bunny[1];

            // check if player will die
            if ((IsValid(bunnyRow - 1, bunnyCol) && lair[bunnyRow - 1][bunnyCol] == 'P') ||
                (IsValid(bunnyRow, bunnyCol + 1) && lair[bunnyRow][bunnyCol + 1] == 'P') ||
                (IsValid(bunnyRow + 1, bunnyCol) && lair[bunnyRow + 1][bunnyCol] == 'P') ||
                (IsValid(bunnyRow, bunnyCol - 1) && lair[bunnyRow][bunnyCol - 1] == 'P'))
            {
                isDead = true;
            }

            // up
            if (IsValid(bunnyRow - 1, bunnyCol) && lair[bunnyRow - 1][bunnyCol] != 'B')
            {
                lair[bunnyRow - 1][bunnyCol] = 'B';
            }

            // right
            if (IsValid(bunnyRow, bunnyCol + 1) && lair[bunnyRow][bunnyCol + 1] != 'B')
            {
                lair[bunnyRow][bunnyCol + 1] = 'B';
            }

            // down
            if (IsValid(bunnyRow + 1, bunnyCol) && lair[bunnyRow + 1][bunnyCol] != 'B')
            {
                lair[bunnyRow + 1][bunnyCol] = 'B';
            }

            // left
            if (IsValid(bunnyRow, bunnyCol - 1) && lair[bunnyRow][bunnyCol - 1] != 'B')
            {
                lair[bunnyRow][bunnyCol - 1] = 'B';
            }
        }

        private static bool IsValid(int row, int col)
        {
            if (row < 0 || row >= lair.Length)
            {
                return false;
            }

            if (col < 0 || col >= lair[row].Length)
            {
                return false;
            }

            return true;
        }

        private static List<int[]> GetCurrentBunniesPosition()
        {
            List<int[]> positions = new List<int[]>();
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'B')
                    {
                        positions.Add(new int[] { row, col });
                    }
                }
            }

            return positions;
        }

        private static void Print(char[][] lair)
        {
            for (int i = 0; i < lair.Length; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }
        }
    }
}
