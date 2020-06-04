using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        public static void Main()
        {
            string cmd = Console.ReadLine();

            ListyIterator<string> collection;
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (cmdArgs.Length == 1)
            {
                collection = new ListyIterator<string>(new List<string>());
            }
            else
            {
                collection = new ListyIterator<string>(cmdArgs.Skip(1).ToList());
            }

            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                switch (cmd)
                {
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "Print":
                        try
                        {
                            collection.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(' ', collection));
                        break;
                }
            }
        }
    }
}