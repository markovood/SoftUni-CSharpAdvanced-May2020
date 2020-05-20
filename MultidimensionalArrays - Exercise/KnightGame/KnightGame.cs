using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    public class KnightGame
    {
        private static char[][] board;

        public static void Main()
        {
            // populate
            int N = int.Parse(Console.ReadLine());
            board = new char[N][];
            for (int i = 0; i < N; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                board[i] = rowValues;
            }

            // count how many from ordered will be removed until all the rest remain with 0 victims
            int removed = 0;
            while (true)
            {
                // record all knights coordinates and count possible victims
                Dictionary<int[], int> knightsAndVictims = GetKnightsAndVictims();

                // order knights by number of victims descending 
                Dictionary<int[], int> ordered = OrderByVictimsDescending(knightsAndVictims);

                if (ordered.All(k => k.Value == 0))
                {
                    break;
                }

                // every time remove the one with most victims
                int[] knight = ordered.First().Key;
                int row = knight[0];
                int col = knight[1];
                board[row][col] = '0';

                removed++;
            }

            Console.WriteLine(removed);
        }

        private static Dictionary<int[], int> OrderByVictimsDescending(Dictionary<int[], int> knightsAndVictims)
        {
            return knightsAndVictims
                .OrderByDescending(k => k.Value)
                .ToDictionary(k => k.Key, k => k.Value);
        }

        private static Dictionary<int[], int> GetKnightsAndVictims()
        {
            var knightsAndVictims = new Dictionary<int[], int>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        int[] knightCoords = new int[] { i, j };
                        knightsAndVictims.Add(knightCoords, GetNumberOfVictims(knightCoords));
                    }
                }
            }

            return knightsAndVictims;
        }

        private static int GetNumberOfVictims(int[] knightCoords)
        {
            int victims = 0;
            int knightRow = knightCoords[0];
            int knightCol = knightCoords[1];

            int[] possibleMoves = new int[]
            {
                knightRow - 2,
                knightCol + 1,
                knightRow - 1,
                knightCol + 2,
                knightRow + 1,
                knightCol + 2,
                knightRow + 2,
                knightCol + 1,
                knightRow + 2,
                knightCol - 1,
                knightRow + 1,
                knightCol - 2,
                knightRow - 1,
                knightCol - 2,
                knightRow - 2,
                knightCol - 1
            };

            for (int i = 0; i < possibleMoves.Length - 1; i += 2)
            {
                if (IsValid(possibleMoves[i], possibleMoves[i + 1]))
                {
                    if (board[possibleMoves[i]][possibleMoves[i + 1]] == 'K')
                    {
                        victims++;
                    }
                }
            }

            return victims;
        }

        private static bool IsValid(int row, int col)
        {
            if (row < 0 || row >= board.Length)
            {
                return false;
            }

            if (col < 0 || col >= board[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
