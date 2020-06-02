using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class GenericCountMethodDouble
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < N; i++)
            {
                double num = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(num);
                boxes.Add(box);
            }

            double numToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(Count(boxes, numToCompare));
        }

        public static int Count<T>(List<Box<T>> list, T element) where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.Value.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
