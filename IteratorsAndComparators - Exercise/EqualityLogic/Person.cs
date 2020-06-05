using System;

namespace EqualityLogic
{
    // see details on generating overrides of Equals and GetHashCode:
    // https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2019
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int CompareTo(Person person)
        {
            int equality = this.Name.CompareTo(person.Name);
            if (equality == 0)
            {
                return this.Age.CompareTo(person.Age);
            }
            else
            {
                return equality;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                var objAsPerson = obj as Person;
                return this.Name == objAsPerson.Name && this.Age == objAsPerson.Age;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);
        }
    }
}
