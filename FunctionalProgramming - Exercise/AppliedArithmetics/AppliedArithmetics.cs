using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    public class AppliedArithmetics
    {
        private static List<int> numbers;

        public static void Main()
        {
            numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Action<List<int>> execute = null;
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end")
                {
                    break;
                }

                switch (cmd)
                {
                    case "add":
                        if (execute == null)
                        {
                            // execute = Add;
                            execute = (x) =>
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i]++;
                                }
                            };
                        }
                        else
                        {
                            // execute += Add;
                            execute += (x) =>
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i]++;
                                }
                            };
                        }

                        break;
                    case "multiply":
                        if (execute == null)
                        {
                            // execute = Multiply;
                            execute = (x) => 
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i] *= 2;
                                }
                            };
                        }
                        else
                        {
                            // execute += Multiply;
                            execute += (x) =>
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i] *= 2;
                                }
                            };
                        }

                        break;
                    case "subtract":
                        if (execute == null)
                        {
                            // execute = Subtract;
                            execute = (x) =>
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i]--;
                                }
                            };
                        }
                        else
                        {
                            // execute += Subtract;
                            execute += (x) =>
                            {
                                for (int i = 0; i < x.Count; i++)
                                {
                                    x[i]--;
                                }
                            };
                        }

                        break;
                    case "print":
                        if (execute == null)
                        {
                            // execute = Print;
                            execute = x => Console.WriteLine(string.Join(' ', x));
                        }
                        else
                        {
                            // execute += Print;
                            execute += x => Console.WriteLine(string.Join(' ', x));
                        }

                        break;
                }
            }

            execute(numbers);
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void Subtract(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        private static void Multiply(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }
        }

        private static void Add(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]++;
            }
        }
    }
}
