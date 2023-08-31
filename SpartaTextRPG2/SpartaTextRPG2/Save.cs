using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG2
{
    internal class Save
    {
        public Character character;
        public Potion potion;
        public List<Item> saveItems;
        public int MpCount;
        public int HpCount;
        public int saveDungeonLevel;
        public void SaveInformation(Character _character, Potion _potion, List<Item>_items,int _dungeonLevel)
        {
            character = _character;
            potion = _potion;
            MpCount = Potion.mpPotionCount;
            HpCount = Potion.hpPotionCount;
            saveItems = _items;
            saveDungeonLevel = _dungeonLevel;
        }    
    }
}