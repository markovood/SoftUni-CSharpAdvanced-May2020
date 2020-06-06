using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sorted = coins.OrderBy(c => c).ToList();
        var selectedCoins = new Dictionary<int, int>();// key: coinValue, value: coinCount

        while (true)
        {
            if (targetSum == 0)
            {
                break;
            }

            if (sorted.Count == 0 && targetSum != 0)
            {
                throw new InvalidOperationException("Error");
            }

            int greatestValueCoin = sorted[sorted.Count - 1];
            int coinMaxCount = targetSum / greatestValueCoin;

            if (coinMaxCount > 0)
            {
                selectedCoins.Add(greatestValueCoin, coinMaxCount);
            }

            int currentSum = greatestValueCoin * coinMaxCount;
            targetSum -= currentSum;

            sorted.RemoveAt(sorted.Count - 1);
        }

        return selectedCoins;
    }
}