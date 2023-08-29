using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG2
{
    public class Character  // 캐릭터 정보를 담당하는 클래스  
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public float Atk { get; set; }
        public int Def { get; set; }
        public int Mp { get; set; }
        public float Gold { get; set; }
        public int CurHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Exp { get; set; }
        public int TotalExp { get; set; }
        public int CurMp { get; set; }

        public int MaxMp { get; set; }
        public bool MyTurn { get; set; }


        public Character(string name, string job, int level, float atk, int def, float gold, int curHealth, int maxHealth, int exp, int totalExp, int curMp, int maxMp, bool myTurn)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Gold = gold;
            CurHealth = curHealth;
            MaxHealth = maxHealth;
            Exp = exp;
            TotalExp = totalExp;
            CurMp = curMp;
            MaxMp = maxMp;
            MyTurn = myTurn;
        }

        public void LevelUp()
        {
            Atk += 0.5f;             // 레벨업 시 기본 공격력 + 0.5, 방어력 + 1
            Def += 1;
            Exp = Exp - TotalExp;
            Level += 1;
            TotalExp += (20 + (Level - 1) * 5);         // 1는 10 필요, 2~3은 35필요, 3~4는 65, 4~5는 100, 만렙은 5이며 exp증가 X
                                                        //레벨업은 player.Level++ / totalExp를 그에 맞게 올림 / totalExp는 += 20 + (level-1)*5(레벨이 2 이상이면)
        }
    }
}
