using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (personInfo[0] == "END")
                {
                    break;
                }

                var person = new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                people.Add(person);
            }

            int N = int.Parse(Console.ReadLine());
            Person personForComparison = people[N - 1];
            people.RemoveAt(N - 1);
            int matches = 1;
            foreach (var person in people)
            {
                if (person.CompareTo(personForComparison) == 0)
                {
                    matches++;
                }
            }

            string output = matches == 1 ?  "No matches" :  $"{matches} {people.Count + 1 - matches} {people.Count + 1}";
            Console.WriteLine(output);
        }
    }
}
