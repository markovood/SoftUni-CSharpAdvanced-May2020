using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            Stack.Stack<int> stack = new Stack.Stack<int>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "Push":
                        foreach (var numStr in cmdArgs.Skip(1))
                        {
                            stack.Push(int.Parse(numStr));
                        }

                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No elements");
                        }

                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var num in stack)
                {
                    Console.WriteLine(num);
                } 
            }
        }
    }
}
