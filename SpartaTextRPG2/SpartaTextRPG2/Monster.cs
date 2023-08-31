using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG2
{
    public class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }
        public int CurHealth { get; set; }
        public int Atk { get; set; }

        public bool IsDead { get; set; }

        public int Boss { get; set; }

        public Monster(string name, int level, int maxHealth, int curHealth, int atk, bool isDead, int boss)
        {
            Name = name;
            Level = level;
            MaxHealth = maxHealth;
            CurHealth = curHealth;
            Atk = atk;
            IsDead = isDead;
            Boss = boss;
        }

        public void BossSkill()
        {
            switch(Boss)
            {
                case 0:

                    break;
            }
        }
    }
}
