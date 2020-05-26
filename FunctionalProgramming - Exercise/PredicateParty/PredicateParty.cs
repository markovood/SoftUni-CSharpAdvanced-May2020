using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PredicateParty
{
    public class PredicateParty
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Party!")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string argument = cmdArgs[1];
                string value = cmdArgs[2];

                Predicate<string> startsWithPredicate = str => str.StartsWith(value);
                Predicate<string> endsWithPredicate = str => str.EndsWith(value);
                Predicate<string> lengthPredicate = str => str.Length == int.Parse(value);

                Func<List<string>, Predicate<string>, int> removeFunc = (list, predicate) => list.RemoveAll(predicate);
                Action<List<string>, Predicate<string>> doubleAction = (list, predicate) =>
                {
                    list.FindAll(predicate).ForEach(x => list.Insert(list.IndexOf(x), x));
                };

                switch (cmdType)
                {
                    case "Double":
                        switch (argument)
                        {
                            case "StartsWith":
                                doubleAction(guests, startsWithPredicate);
                                break;
                            case "EndsWith":
                                doubleAction(guests, endsWithPredicate);
                                break;
                            case "Length":
                                doubleAction(guests, lengthPredicate);
                                break;
                        }

                        break;
                    case "Remove":
                        switch (argument)
                        {
                            case "StartsWith":
                                removeFunc(guests, startsWithPredicate);
                                break;
                            case "EndsWith":
                                removeFunc(guests, endsWithPredicate);
                                break;
                            case "Length":
                                removeFunc(guests, lengthPredicate);
                                break;
                        }

                        break;
                }


            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}