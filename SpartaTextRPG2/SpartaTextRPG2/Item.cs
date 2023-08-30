using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG2
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public float Power { get; set; }
        public int Price { get; set; }
        public string Description;
        public bool PlayerEquipped { get; set; }
        public string Owner { get; set; }

        public Item(string name, string type, float power, string description, bool playerEquipped, string owner)
        {
            Name = name;
            Type = type;
            Power = power;
            Description = description;
            PlayerEquipped = playerEquipped;
            Owner = owner;
        }
    }
}
