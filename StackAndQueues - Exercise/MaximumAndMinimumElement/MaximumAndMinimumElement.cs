using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    public class MaximumAndMinimumElement
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string query = Console.ReadLine();
                switch (query)
                {
                    default:
                        string[] tokens = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        stack.Push(int.Parse(tokens[1]));
                        break;
                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }

                        break;
                    case "3":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }

                        break;
                    case "4":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}