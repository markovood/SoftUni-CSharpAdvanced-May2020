using System;

namespace ImplementingCustomList
{
    public class StartUp
    {
        public static void Main()
        {
            // Creating new CustomList test
            CustomList list = new CustomList();
            Console.WriteLine(list.Count);// 0

            // testing Add(int element)
            list.Add(2); 
            list.Add(4);
            list.Add(6);// resizing
            Console.WriteLine(list.Count);// 3

            // testing indexation
            Console.WriteLine(list[1]);// 4
            //Console.WriteLine(list[-1]);// getter throws IndexOutOfRangeException
            //Console.WriteLine(list[5]);// getter throws IndexOutOfRangeException
            //list[-5] = 0;// setter throws IndexOutOfRangeException
            //list[5] = 0;// setter throws IndexOutOfRangeException
            list[0] = 200;
            Console.WriteLine(list[0]);

            // testing RemoveAt(int index)
            int removed200 = list.RemoveAt(0);// shifting
            int removed4 = list.RemoveAt(0);// optimizing
            Console.WriteLine(removed4);// 4
            Console.WriteLine(list.Count);// 1
            //list.RemoveAt(-1);// throws ArgumentOutOfRangeException
            //list.RemoveAt(5);// throws ArgumentOutOfRangeException

            // testing Contains(int element)
            Console.WriteLine(list.Contains(6));// True
            Console.WriteLine(list.Contains(200));// False

            // testing Swap(int index1, int index2)
            list.Add(60);
            list.Add(600);
            //list.Swap(-5, 2);// throws ArgumentOutOfRangeException
            //list.Swap(5, 2);// throws ArgumentOutOfRangeException
            //list.Swap(0, -2);// throws ArgumentOutOfRangeException
            //list.Swap(0, 5);// throws ArgumentOutOfRangeException
            Console.WriteLine(list);
            list.Swap(0, 2);
            Console.WriteLine(list);

            // testing InsertAt(int index)
            //list.InsertAt(-1, 6000);// throws ArgumentOutOfRangeException
            //list.InsertAt(10, 6000);// throws ArgumentOutOfRangeException
            list.InsertAt(1, 6000);// shifting to the right
            list.InsertAt(2, 60000);// resizing, shifting to the right
            Console.WriteLine(list.Count);// 5
            list.InsertAt(list.Count - 1, 900);
            //list.InsertAt(list.Count, 900);// throws IndexOutOfRangeException
            Console.WriteLine(list);// 600 6000 60000 60 6

            // testing Reverse()
            list.Reverse();
            Console.WriteLine(list);
        }
    }
}
