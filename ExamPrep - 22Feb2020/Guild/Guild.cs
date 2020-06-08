using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private HashSet<Player> players;

        public Guild(string name, int capacity)
        {
            this.players = new HashSet<Player>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.players.Count;

        public void AddPlayer(Player player)
        {
            if (this.players.Count + 1 <= this.Capacity)
            {
                this.players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            int removed = this.players.RemoveWhere(p => p.Name == name);
            if (removed > 0)
            {
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            this.players.First(p => p.Name == name && p.Rank != "Member").Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            this.players.First(p => p.Name == name && p.Rank != "Trial").Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] removed = this.players.Where(pl => pl.Class == @class).ToArray();
            this.players.RemoveWhere(pl => pl.Class == @class);

            return removed;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
