using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Rabbit>(this.Capacity);
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.Count + 1 <= this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            int removed = this.data.RemoveAll(r => r.Name == name);
            if (removed > 0)
            {
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbitToSell = this.data.FirstOrDefault(r => r.Name == name);
            rabbitToSell.Available = false;
            return rabbitToSell;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var filtered = this.data
                .Where(r => r.Species == species)
                .ToArray();

            foreach (var rabbit in filtered)
            {
                rabbit.Available = false;
            }

            return filtered;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data)
            {
                if (rabbit.Available)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
