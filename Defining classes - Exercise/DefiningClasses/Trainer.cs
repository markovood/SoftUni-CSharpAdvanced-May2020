using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
		private string name;
		private int badgesCount;
		private List<Pokemon> pokemons;

		public Trainer(string name, List<Pokemon> pokemons)
		{
			this.Name = name;
			this.badgesCount = 0;
			this.pokemons = pokemons;
		}

		public List<Pokemon> Pokemons { get => this.pokemons; set => this.pokemons = value; }
		public string Name { get => this.name; private set => this.name = value; }
		public int Badges { get => this.badgesCount; set => this.badgesCount = value; }
	}
}
