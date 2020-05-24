using System;
using System.Collections.Generic;

namespace ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<IEnumerable<string>> print = PrintOnConsole;
            
            print(names);
        }

        private static void PrintOnConsole(IEnumerable<string> collection)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection));
        }
    }
}
