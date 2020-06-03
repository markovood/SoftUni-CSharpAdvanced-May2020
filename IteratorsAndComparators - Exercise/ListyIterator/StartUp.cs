using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            string cmd = Console.ReadLine();

            ListyIterator<string> iterator;
            string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (cmdArgs.Length == 1)
            {
                iterator = new ListyIterator<string>(new List<string>());
            }
            else
            {
                iterator = new ListyIterator<string>(cmdArgs.Skip(1).ToList());
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
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                }
            }
        }
    }
}
