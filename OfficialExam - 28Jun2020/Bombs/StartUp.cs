using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    public class StartUp
    {
        private static int daturaCount;
        private static int cherryCount;
        private static int smokeDecoyCount;

        public static void Main()
        {
            int[] effects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> bombEffects = new Queue<int>(effects);

            int[] casing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> bombCasing = new Stack<int>(casing);

            daturaCount = 0;//40
            cherryCount = 0;//60
            smokeDecoyCount = 0;//120

            while (true)
            {
                if (bombCasing.Count == 0)
                {
                    break;
                }

                if (bombEffects.Count == 0)
                {
                    break;
                }

                if (IsPouchFull())
                {
                    break;
                }

                int bEffect = bombEffects.Peek();
                int bCase = bombCasing.Peek();

                switch (bEffect + bCase)
                {
                    case 40:
                        daturaCount++;
                        bombEffects.Dequeue();
                        bombCasing.Pop();
                        break;
                    case 60:
                        cherryCount++;
                        bombEffects.Dequeue();
                        bombCasing.Pop();
                        break;
                    case 120:
                        smokeDecoyCount++;
                        bombEffects.Dequeue();
                        bombCasing.Pop();
                        break;
                    default:
                        bCase -= 5;
                        bombCasing.Pop();
                        bombCasing.Push(bCase);
                        break;
                }
            }

            if (IsPouchFull())
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyCount}");
        }

        private static bool IsPouchFull()
        {
            if (daturaCount >= 3 &&
                cherryCount >= 3 &&
                smokeDecoyCount >= 3)
            {
                return true;
            }

            return false;
        }
    }
}