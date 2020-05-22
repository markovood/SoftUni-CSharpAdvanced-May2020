using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    public class TheVLogger
    {
        public static void Main()
        {
            // vloggers
            var usersAndFollowers = new Dictionary<string, List<string>>();
            var usersAndFollowings = new Dictionary<string, List<string>>();

            // populate vloggers collections
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Statistics")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string username = cmdArgs[0];
                string commandWord = cmdArgs[1];
                switch (commandWord)
                {
                    case "joined":
                        if (!usersAndFollowers.ContainsKey(username))
                        {
                            usersAndFollowers.Add(username, new List<string>());
                            usersAndFollowings.Add(username, new List<string>());
                        }

                        break;
                    case "followed":
                        string following = cmdArgs[2];
                        if (username != following &&
                            usersAndFollowers.ContainsKey(username) &&
                            usersAndFollowers.ContainsKey(following) &&
                            !usersAndFollowings[username].Contains(following))
                        {
                            usersAndFollowings[username].Add(following);
                            usersAndFollowers[following].Add(username);
                        }

                        break;
                }
            }

            // print statistics
            // part 1
            Console.WriteLine($"The V-Logger has a total of {usersAndFollowers.Count} vloggers in its logs.");

            // part 2
            var usersOrderedByFollowers = usersAndFollowers
                                            .OrderByDescending(u => u.Value.Count)
                                            .ThenBy(u => usersAndFollowings[u.Key].Count)
                                            .ToDictionary(u => u.Key, u => u.Value);

            var mostFamousUser = usersOrderedByFollowers.First();
            Console.WriteLine($"1. {mostFamousUser.Key} : {mostFamousUser.Value.Count} followers, {usersAndFollowings[mostFamousUser.Key].Count} following");

            if (mostFamousUser.Value.Count > 0)
            {
                var orederedLexicographically = mostFamousUser
                                                            .Value
                                                            .OrderBy(f => f);

                foreach (var follower in orederedLexicographically)
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            // part 3

            int position = 2;
            foreach (var user in usersOrderedByFollowers.Keys.Skip(1))
            {
                Console.WriteLine($"{position}. {user} : {usersOrderedByFollowers[user].Count} followers, {usersAndFollowings[user].Count} following");
                position++;
            }
        }
    }
}
