using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class GenericCountMethodString
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                Box<string> box = new Box<string>(str);
                boxes.Add(box);
            }

            string elementToCompare = Console.ReadLine();
            Console.WriteLine(Count(boxes, elementToCompare));
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
