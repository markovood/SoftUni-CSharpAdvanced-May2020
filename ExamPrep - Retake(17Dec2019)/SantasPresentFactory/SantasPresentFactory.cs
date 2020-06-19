using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    public class SantasPresentFactory
    {
        public static void Main()
        {
            int[] materialsCounts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> materials = new Stack<int>(materialsCounts);

            int[] magicLevels = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> magics = new Queue<int>(magicLevels);

            var constants = new Dictionary<int, string>()
            {
                { 150, "Doll" },
                { 250, "Wooden train" },
                { 300, "Teddy bear" },
                { 400, "Bicycle" }
            };

            SortedDictionary<string, int> presents = new SortedDictionary<string, int>();
            while (true)
            {
                if (materials.Count == 0 || magics.Count == 0)
                {
                    break;
                }

                // crafting
                int material = materials.Peek();
                int magic = magics.Peek();
                int result = material * magic;
                if (constants.ContainsKey(result))
                {
                    if (presents.ContainsKey(constants[result]))
                    {
                        presents[constants[result]]++;
                    }
                    else
                    {
                        presents.Add(constants[result], 1);
                    }

                    materials.Pop();
                    magics.Dequeue();
                }
                else
                {
                    if (result < 0)
                    {
                        int sum = materials.Pop() + magics.Dequeue();
                        materials.Push(sum);
                    }
                    else if (result > 0)
                    {
                        magics.Dequeue();
                        materials.Push(materials.Pop() + 15);
                    }
                    else
                    {
                        if (material == 0)
                        {
                            materials.Pop();
                        }

                        if (magic == 0)
                        {
                            magics.Dequeue();
                        }
                    }
                }
            }

            // output
            if ((presents.ContainsKey("Doll") && presents.ContainsKey("Wooden train")) ||
                (presents.ContainsKey("Teddy bear") && presents.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magics.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magics)}");
            }

            foreach (var present in presents)
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}