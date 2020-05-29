using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.members.Add(person);
        }

        public Person GetOldestMember()
        {
            return members.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
