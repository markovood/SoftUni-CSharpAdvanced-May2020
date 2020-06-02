using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < N; i++)
            {
                int integer = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(integer);
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indexes[0], indexes[1]);
            Console.WriteLine(string.Join(Environment.NewLine, boxes));
        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
