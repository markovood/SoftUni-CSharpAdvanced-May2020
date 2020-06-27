using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public Item Item { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hero: {this.Name} - {this.Level}lvl");
            sb.AppendLine(this.Item.ToString());

            return sb.ToString().Trim();
        }
    }
}
