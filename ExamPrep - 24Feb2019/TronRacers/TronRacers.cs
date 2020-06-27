using System;

namespace TronRacers
{
    public class TronRacers
    {
        private static char[][] field;
        private static int fRow;
        private static int fCol;
        private static int sRow;
        private static int sCol;
        private static bool isFDead = false;
        private static bool isSDead = false;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            field = new char[size][];
            for (int i = 0; i < size; i++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();

                int indexFCol = Array.IndexOf(rowValues, 'f');
                if (indexFCol >= 0)
                {
                    fRow = i;
                    fCol = indexFCol;
                }

                int indexSCol = Array.IndexOf(rowValues, 's');
                if (indexSCol >= 0)
                {
                    sRow = i;
                    sCol = indexSCol;
                }

                field[i] = rowValues;
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string fDirection = cmdArgs[0];
                string sDirection = cmdArgs[1];

                switch (fDirection)
                {
                    case "up":
                        fRow--;
                        if (fRow < 0)
                        {
                            fRow = field.Length - 1;
                        }

                        if (field[fRow][fCol] != 's')
                        {
                            field[fRow][fCol] = 'f';
                        }
                        else
                        {
                            field[fRow][fCol] = 'x';
                            isFDead = true;
                        }

                        break;
                    case "down":
                        fRow++;
                        if (fRow >= field.Length)
                        {
                            fRow = 0;
                        }

                        if (field[fRow][fCol] != 's')
                        {
                            field[fRow][fCol] = 'f';
                        }
                        else
                        {
                            field[fRow][fCol] = 'x';
                            isFDead = true;
                        }

                        break;
                    case "left":
                        fCol--;
                        if (fCol < 0)
                        {
                            fCol = field[0].Length - 1;
                        }

                        if (field[fRow][fCol] != 's')
                        {
                            field[fRow][fCol] = 'f';
                        }
                        else
                        {
                            field[fRow][fCol] = 'x';
                            isFDead = true;
                        }

                        break;
                    case "right":
                        fCol++;
                        if (fCol >= field[0].Length)
                        {
                            fCol = 0;
                        }

                        if (field[fRow][fCol] != 's')
                        {
                            field[fRow][fCol] = 'f';
                        }
                        else
                        {
                            field[fRow][fCol] = 'x';
                            isFDead = true;
                        }

                        break;
                }

                if (isFDead)
                {
                    break;
                }

                switch (sDirection)
                {
                    case "up":
                        sRow--;
                        if (sRow < 0)
                        {
                            sRow = field.Length - 1;
                        }

                        if (field[sRow][sCol] != 'f')
                        {
                            field[sRow][sCol] = 's';
                        }
                        else
                        {
                            field[sRow][sCol] = 'x';
                            isSDead = true;
                        }

                        break;
                    case "down":
                        sRow++;
                        if (sRow >= field.Length)
                        {
                            sRow = 0;
                        }

                        if (field[sRow][sCol] != 'f')
                        {
                            field[sRow][sCol] = 's';
                        }
                        else
                        {
                            field[sRow][sCol] = 'x';
                            isSDead = true;
                        }

                        break;
                    case "left":
                        sCol--;
                        if (sCol < 0)
                        {
                            sCol = field[0].Length - 1;
                        }

                        if (field[sRow][sCol] != 'f')
                        {
                            field[sRow][sCol] = 's';
                        }
                        else
                        {
                            field[sRow][sCol] = 'x';
                            isSDead = true;
                        }

                        break;
                    case "right":
                        sCol++;
                        if (sCol >= field[0].Length)
                        {
                            sCol = 0;
                        }

                        if (field[sRow][sCol] != 'f')
                        {
                            field[sRow][sCol] = 's';
                        }
                        else
                        {
                            field[sRow][sCol] = 'x';
                            isSDead = true;
                        }

                        break;
                }

                if (isSDead)
                {
                    break;
                }
            }

            PrintField();
        }

        public static void PrintField()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}