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

        public void SaveInformation(Character _character, Potion _potion)
        {
            character = _character;
            potion = _potion;
        }
        public void outputInformation(Character _character, Potion _potion)
        {
            _character = character;
            _potion = potion;
        }
    }
}