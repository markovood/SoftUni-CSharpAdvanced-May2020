using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            string[] guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            List<KeyValuePair<string, int>> removed = new List<KeyValuePair<string, int>>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Print")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string filterType = cmdArgs[1];
                string filterParameter = cmdArgs[2];

                Predicate<string> startsWithPredicate = str => str.StartsWith(filterParameter);
                Predicate<string> endsWithPredicate = str => str.EndsWith(filterParameter);
                Predicate<string> lengthPredicate = str => str.Length == int.Parse(filterParameter);
                Predicate<string> containsPredicate = str => str.Contains(filterParameter);

                Func<string[], Predicate<string>, List<KeyValuePair<string, int>>> addFilterFunc = (arr, constraint) =>
                 {
                     var removed = new List<KeyValuePair<string, int>>();

                     string[] found = Array.FindAll(arr, constraint);
                     foreach (var item in found)
                     {
                         int index = Array.IndexOf(arr, item);
                         arr[index] = string.Empty;
                         removed.Add(new KeyValuePair<string, int>(item, index));
                     }

                     return removed;
                 };

                Action<List<KeyValuePair<string, int>>, Predicate<string>, string[]> removeFilterAction = (removed, constraint, arr) =>
                 {
                     var toRestore = removed.FindAll(x => constraint(x.Key));
                     toRestore.ForEach(kvp => arr[kvp.Value] = kvp.Key);
                 };



                switch (command)
                {
                    case "Add filter":
                        // removes all names according to the filter's constraint
                        switch (filterType)
                        {
                            case "Starts with":
                                removed.AddRange(addFilterFunc(guests, startsWithPredicate));
                                break;
                            case "Ends with":
                                removed.AddRange(addFilterFunc(guests, endsWithPredicate));
                                break;
                            case "Length":
                                removed.AddRange(addFilterFunc(guests, lengthPredicate));
                                break;
                            case "Contains":
                                removed.AddRange(addFilterFunc(guests, containsPredicate));
                                break;
                        }

                        break;
                    case "Remove filter":
                        // adds back removed names (to the original positions)
                        switch (filterType)
                        {
                            case "Starts with":
                                removeFilterAction(removed, startsWithPredicate, guests);
                                break;
                            case "Ends with":
                                removeFilterAction(removed, endsWithPredicate, guests);
                                break;
                            case "Length":
                                removeFilterAction(removed, lengthPredicate, guests);
                                break;
                            case "Contains":
                                removeFilterAction(removed, containsPredicate, guests);
                                break;
                        }

                        break;
                }
            }

            // print
            // remove all empty cells for correct printout with string.Join
            guests = Array.FindAll(guests, x => x != string.Empty);
            Console.WriteLine(string.Join(' ', guests));
        }
    }
}