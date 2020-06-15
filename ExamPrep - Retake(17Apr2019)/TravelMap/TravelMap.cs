using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelMap
{
    public class TravelMap
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> countriesTownsAndCost = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(" > ", StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0] == "END")
                {
                    break;
                }

                string country = inputArgs[0];
                string town = inputArgs[1];
                int cost = int.Parse(inputArgs[2]);

                if (countriesTownsAndCost.ContainsKey(country))
                {
                    if (countriesTownsAndCost[country].ContainsKey(town))
                    {
                        if (countriesTownsAndCost[country][town] > cost )
                        {
                            countriesTownsAndCost[country][town] = cost;
                        }
                    }
                    else
                    {
                        countriesTownsAndCost[country].Add(town, cost);
                    }
                }
                else
                {
                    countriesTownsAndCost.Add(country, new Dictionary<string, int>() { { town, cost } });
                }
            }

            // print
            foreach (var country in countriesTownsAndCost.Keys)
            {
                Console.Write($"{country} ->");
                foreach ((string town, int cost) in countriesTownsAndCost[country].OrderBy(x => x.Value))
                {
                    Console.Write($" {town} -> {cost}");
                }

                Console.WriteLine();
            }
        }
    }
}