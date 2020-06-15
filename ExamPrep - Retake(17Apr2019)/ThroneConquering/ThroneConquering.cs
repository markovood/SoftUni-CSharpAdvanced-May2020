using System;

namespace ThroneConquering
{
    public class ThroneConquering
    {
        private static int parisRow;
        private static int parisCol;
        private static char[][] field;
        private static int energyParis;

        public static void Main()
        {
            energyParis = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());

            field = new char[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            GetParisPosition();

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = cmdArgs[0];
                int spartanRow = int.Parse(cmdArgs[1]);
                int spartanCol = int.Parse(cmdArgs[2]);

                // spawn spartan
                field[spartanRow][spartanCol] = 'S';

                // move Paris
                field[parisRow][parisCol] = '-';
                switch (direction)
                {
                    case "up":
                        parisRow--;
                        break;
                    case "down":
                        parisRow++;
                        break;
                    case "left":
                        parisCol--;
                        break;
                    case "right":
                        parisCol++;
                        break;
                }

                ValidateMove();
                energyParis--;
                ProcessCurrentSymbol();
                field[parisRow][parisCol] = 'P';
            }
        }

        private static void ProcessCurrentSymbol()
        {
            switch (field[parisRow][parisCol])
            {
                case '-':
                    if (energyParis <= 0)
                    {
                        KillParis();
                    }

                    break;
                case 'S':
                    energyParis -= 2;
                    if (energyParis <= 0)
                    {
                        KillParis();
                    }

                    break;
                case 'H':
                    Win();
                    break;
            }
        }

        private static void Win()
        {
            // Paris wins
            field[parisRow][parisCol] = '-';
            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energyParis}");
            PrintField();
            Environment.Exit(0);
        }

        private static void KillParis()
        {
            // Paris dies
            field[parisRow][parisCol] = 'X';
            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            PrintField();
            Environment.Exit(0);
        }

        private static void ValidateMove()
        {
            if (parisRow < 0)
            {
                parisRow = 0;
            }
            else if (parisRow >= field.Length)
            {
                parisRow = field.Length - 1;
            }

            if (parisCol < 0)
            {
                parisCol = 0;
            }
            else if (parisCol >= field[0].Length)
            {
                parisCol = field[0].Length - 1;
            }
        }

        private static void GetParisPosition()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                        return;
                    }
                }
            }
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