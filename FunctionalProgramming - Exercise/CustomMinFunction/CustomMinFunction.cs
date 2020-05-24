using System;
using System.Linq;

namespace CustomMinFunction
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Func<int[], int> getMinFunc = (x) => 
            //{
            //    int min = int.MaxValue;
            //    foreach (var num in x)
            //    {
            //        if (num < min)
            //        {
            //            min = num;
            //        }
            //    }

            //    return min;
            //};

            Func<int[], int> getMinFunc = GetMin;

            Console.WriteLine(getMinFunc(numbers));
        }

        private static int GetMin(int[] collection)
        {
            int min = int.MaxValue;
            foreach (var num in collection)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
