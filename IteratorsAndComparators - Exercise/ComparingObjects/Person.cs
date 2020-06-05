using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo(Person person)
        {
            int equality = this.Name.CompareTo(person.Name);
            if (equality == 0)
            {
                equality = this.Age.CompareTo(person.Age);
                if (equality == 0)
                {
                    return this.Town.CompareTo(person.Town);
                }
                else
                {
                    return equality;
                }
            }
            else
            {
                return equality;
            }
        }
    }
}
