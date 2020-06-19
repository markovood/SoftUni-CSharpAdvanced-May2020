using System;

namespace PresentDelivery
{
    public class PresentDelivery
    {
        private static string[][] neighbourhood;
        private static int totalNiceKids;
        private static int niceKidsLeft;
        private static int santaRow;
        private static int santaCol;

        public static void Main()
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            neighbourhood = new string[size][];
            for (int i = 0; i < size; i++)
            {
                neighbourhood[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < neighbourhood[i].Length; j++)
                {
                    if (neighbourhood[i][j] == "V")
                    {
                        totalNiceKids++;
                    }
                    else if (neighbourhood[i][j] == "S")
                    {
                        santaRow = i;
                        santaCol = j;
                    }
                }
            }

            niceKidsLeft = totalNiceKids;
            // execute cmds
            while (true)
            {
                if (presentsCount == 0)
                {
                    break;
                }

                string direction = Console.ReadLine();
                if (direction == "Christmas morning")
                {
                    break;
                }

                switch (direction)
                {
                    case "up":
                        santaRow--;
                        IsSantaOut();

                        switch (neighbourhood[santaRow][santaCol])
                        {
                            case "X":
                                UpdateFieldUp();
                                break;
                            case "V":
                                UpdateFieldUp();
                                presentsCount--;
                                niceKidsLeft--;
                                if (presentsCount == 0)
                                {
                                    Console.WriteLine("Santa ran out of presents!");
                                    Output();
                                    Environment.Exit(0);
                                }
                                break;
                            case "C":
                                UpdateFieldUp();
                                presentsCount = SpreadPresents(presentsCount);
                                break;
                            case "-":
                                UpdateFieldUp();
                                break;
                        }

                        break;
                    case "down":
                        santaRow++;
                        IsSantaOut();

                        switch (neighbourhood[santaRow][santaCol])
                        {
                            case "X":
                                UpdateFieldDown();
                                break;
                            case "V":
                                UpdateFieldDown();
                                presentsCount--;
                                niceKidsLeft--;
                                if (presentsCount == 0)
                                {
                                    Console.WriteLine("Santa ran out of presents!");
                                    Output();
                                    Environment.Exit(0);
                                }
                                break;
                            case "C":
                                UpdateFieldDown();
                                presentsCount = SpreadPresents(presentsCount);
                                break;
                            case "-":
                                UpdateFieldDown();
                                break;
                        }

                        break;
                    case "left":
                        santaCol--;
                        IsSantaOut();

                        switch (neighbourhood[santaRow][santaCol])
                        {
                            case "X":
                                UpdateFieldLeft();
                                break;
                            case "V":
                                UpdateFieldLeft();
                                presentsCount--;
                                niceKidsLeft--;
                                if (presentsCount == 0)
                                {
                                    Console.WriteLine("Santa ran out of presents!");
                                    Output();
                                    Environment.Exit(0);
                                }
                                break;
                            case "C":
                                UpdateFieldLeft();
                                presentsCount = SpreadPresents(presentsCount);
                                break;
                            case "-":
                                UpdateFieldLeft();
                                break;
                        }

                        break;
                    case "right":
                        santaCol++;
                        IsSantaOut();

                        switch (neighbourhood[santaRow][santaCol])
                        {
                            case "X":
                                UpdateFieldRight();
                                break;
                            case "V":
                                UpdateFieldRight();
                                presentsCount--;
                                niceKidsLeft--;
                                if (presentsCount == 0)
                                {
                                    Console.WriteLine("Santa ran out of presents!");
                                    Output();
                                    Environment.Exit(0);
                                }
                                break;
                            case "C":
                                UpdateFieldRight();
                                presentsCount = SpreadPresents(presentsCount);
                                break;
                            case "-":
                                UpdateFieldRight();
                                break;
                        }

                        break;
                }

                if (presentsCount == 0)
                {
                    break;
                }
            }

            // print neighbourhood
            Output();
        }

        private static int SpreadPresents(int presentsCount)
        {
            // up
            if (neighbourhood[santaRow - 1][santaCol] == "X")
            {
                presentsCount--;
                neighbourhood[santaRow - 1][santaCol] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }
            else if (neighbourhood[santaRow - 1][santaCol] == "V")
            {
                presentsCount--;
                niceKidsLeft--;
                neighbourhood[santaRow - 1][santaCol] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }

            // down
            if (neighbourhood[santaRow + 1][santaCol] == "X")
            {
                presentsCount--;
                neighbourhood[santaRow + 1][santaCol] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }
            else if (neighbourhood[santaRow + 1][santaCol] == "V")
            {
                presentsCount--;
                niceKidsLeft--;
                neighbourhood[santaRow + 1][santaCol] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }

            // left
            if (neighbourhood[santaRow][santaCol - 1] == "X")
            {
                presentsCount--;
                neighbourhood[santaRow][santaCol - 1] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }
            else if (neighbourhood[santaRow][santaCol - 1] == "V")
            {
                presentsCount--;
                niceKidsLeft--;
                neighbourhood[santaRow][santaCol - 1] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }

            // right
            if (neighbourhood[santaRow][santaCol + 1] == "X")
            {
                presentsCount--;
                neighbourhood[santaRow][santaCol + 1] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }
            else if (neighbourhood[santaRow][santaCol + 1] == "V")
            {
                presentsCount--;
                niceKidsLeft--;
                neighbourhood[santaRow][santaCol + 1] = "-";
                if (presentsCount == 0)
                {
                    return presentsCount;
                }
            }

            return presentsCount;
        }

        private static void UpdateFieldRight()
        {
            neighbourhood[santaRow][santaCol] = "S";
            neighbourhood[santaRow][santaCol - 1] = "-";
        }

        private static void UpdateFieldLeft()
        {
            neighbourhood[santaRow][santaCol] = "S";
            neighbourhood[santaRow][santaCol + 1] = "-";
        }

        private static void UpdateFieldDown()
        {
            neighbourhood[santaRow][santaCol] = "S";
            neighbourhood[santaRow - 1][santaCol] = "-";
        }

        private static void UpdateFieldUp()
        {
            neighbourhood[santaRow][santaCol] = "S";
            neighbourhood[santaRow + 1][santaCol] = "-";
        }

        private static void IsSantaOut()
        {
            if (santaRow < 0 ||
                santaRow >= neighbourhood.Length ||
                santaCol < 0 ||
                santaCol >= neighbourhood[0].Length)
            {
                Console.WriteLine("Santa ran out of presents!");
                Output();
                Environment.Exit(0);
            }
        }

        private static void Output()
        {
            PrintNeighbourhood();

            if (niceKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {totalNiceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsLeft} nice kid/s.");
            }
        }

        private static void PrintNeighbourhood()
        {
            foreach (var row in neighbourhood)
            {
                Console.WriteLine(string.Join(" ", row).Trim());
            }
        }
    }
}