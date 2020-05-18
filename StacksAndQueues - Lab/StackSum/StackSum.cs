using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    public class StackSum
    {
        public static void Main()
        {
            int[] ints = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(ints);
            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "end")
                {
                    break;
                }

                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.StartsWith("add"))
                {
                    stack.Push(int.Parse(commandTokens[1]));
                    stack.Push(int.Parse(commandTokens[2]));
                }
                else if (command.StartsWith("remove"))
                {
                    int length = int.Parse(commandTokens[1]);
                    if (stack.Count >= length)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}