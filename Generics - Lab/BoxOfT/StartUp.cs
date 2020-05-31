using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main()
        {
            Box<double> boxInt = new Box<double>();
            boxInt.Add(1.1);
            boxInt.Add(1.2);
            boxInt.Add(1.3);
            boxInt.Add(1.4);
            boxInt.Add(1.5);

            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
}
