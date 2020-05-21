using System;
using System.Collections.Generic;

namespace Wardrobe
{
    public class Wardrobe
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var colorsItemsAndCount = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < N; i++)
            {
                //"{color} -> {item1},{item2},{item3}"
                string[] clothesArgs = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = clothesArgs[0];
                string[] items = clothesArgs[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (colorsItemsAndCount.ContainsKey(color))
                {
                    foreach (var item in items)
                    {
                        if (colorsItemsAndCount[color].ContainsKey(item))
                        {
                            colorsItemsAndCount[color][item]++;
                        }
                        else
                        {
                            colorsItemsAndCount[color].Add(item, 1);
                        }
                    }
                }
                else
                {
                    var itemsAndCount = new Dictionary<string, int>();
                    foreach (var item in items)
                    {
                        if (itemsAndCount.ContainsKey(item))
                        {
                            itemsAndCount[item]++;
                        }
                        else
                        {
                            itemsAndCount.Add(item, 1);
                        }
                    }

                    colorsItemsAndCount.Add(color, itemsAndCount);
                }
            }

            string[] colorAndItemToFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in colorsItemsAndCount.Keys)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var itemAndCount in colorsItemsAndCount[color])
                {
                    if (color == colorAndItemToFind[0] && itemAndCount.Key == colorAndItemToFind[1])
                    {
                        Console.WriteLine($"* {itemAndCount.Key} - {itemAndCount.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itemAndCount.Key} - {itemAndCount.Value}");
                    }
                }
            }
        }
    }
}
