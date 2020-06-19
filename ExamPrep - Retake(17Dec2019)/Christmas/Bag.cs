using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> presents;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;

            this.presents = new List<Present>(this.Capacity);
        }

        public string Color { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.presents.Count;

        public void Add(Present present)
        {
            if (this.Count + 1 <= this.Capacity)
            {
                this.presents.Add(present);
            }
        }

        public bool Remove(string name)
        {
            int result = this.presents.RemoveAll(p => p.Name == name);
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            return this.presents.OrderByDescending(p => p.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return this.presents.FirstOrDefault(p => p.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in this.presents)
            {
                sb.AppendLine(present.ToString().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
