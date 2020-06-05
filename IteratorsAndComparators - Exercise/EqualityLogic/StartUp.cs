using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> people = new HashSet<Person>();
            for (int i = 0; i < N; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                var person = new Person(name, age);

                sortedPeople.Add(person);
                people.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(people.Count);
        }
    }
}
