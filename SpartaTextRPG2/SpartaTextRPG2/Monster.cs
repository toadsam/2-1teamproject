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
        public int Damage { get; set; }

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

        public int BossSkill(int skillNum)
        {
            Damage = Atk;
            switch (skillNum)
            {
                case 0:
                    Damage = Atk;
                    return 0;
                    break;
                case 1:
                    Damage = Atk * 2;
                    return 1;
                    break;
                case 2:
                    CurHealth += 50;
                    if (CurHealth > MaxHealth)
                    {
                        CurHealth = MaxHealth;
                    }
                    return 2;
                    break;
                case 3:
                    //new Monster("미니언", 0, 15, 15, 5, false, 0);
                    return 3;
                    break;
                default:
                    Damage = Atk;
                    return 0;
                    break;
            }
        }
    }
}
