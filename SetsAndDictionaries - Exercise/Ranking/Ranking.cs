using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class Ranking
    {
        public static void Main()
        {
            var contestsAndPasswords = new Dictionary<string, string>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0] == "end of contests")
                {
                    break;
                }

                if (!contestsAndPasswords.ContainsKey(inputArgs[0]))
                {
                    contestsAndPasswords.Add(inputArgs[0], inputArgs[1]);
                }
            }

            var usersContestsAndPoints = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0] == "end of submissions")
                {
                    break;
                }

                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contestsAndPasswords.ContainsKey(contest) && contestsAndPasswords[contest] == password)
                {
                    if (usersContestsAndPoints.ContainsKey(username))
                    {
                        if (usersContestsAndPoints[username].ContainsKey(contest))
                        {
                            if (points > usersContestsAndPoints[username][contest])
                            {
                                usersContestsAndPoints[username][contest] = points;
                            }
                        }
                        else
                        {
                            usersContestsAndPoints[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        usersContestsAndPoints.Add(username, new Dictionary<string, int>() { { contest, points } });
                    }
                }
            }

            string bestCandidate = usersContestsAndPoints.OrderByDescending(u => u.Value.Values.Sum()).First().Key;
            int totalPts = usersContestsAndPoints[bestCandidate].Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate} with total {totalPts} points.");

            var orderedByName = usersContestsAndPoints
                .OrderBy(u => u.Key)
                .ToDictionary(u => u.Key, u => u.Value);

            Console.WriteLine("Ranking:");
            foreach (var user in orderedByName.Keys)
            {
                Console.WriteLine($"{user}");
                var contestsByPts = usersContestsAndPoints[user].OrderByDescending(c => c.Value);
                foreach (var contest in contestsByPts)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
