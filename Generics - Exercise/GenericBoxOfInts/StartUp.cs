using System;

namespace GenericBoxOfInts
{
    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(num);
                Console.WriteLine(box);
            }
        }
    }
}
