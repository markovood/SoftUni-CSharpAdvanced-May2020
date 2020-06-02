using System;

namespace GenericBoxOfStrings
{
    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                Box<string> box = new Box<string>(str);
                Console.WriteLine(box);
            }
        }
    }
}
