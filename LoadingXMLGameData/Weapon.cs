using Microsoft.Xna.Framework;

namespace LoadingXMLGameData
{
    public class Weapon
    {
        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }

        public Weapon(string name, string description, int cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }
        public void Use(GameTime elapsedTime) { }
        public bool IsEquipped { get; set; }
    }
}
