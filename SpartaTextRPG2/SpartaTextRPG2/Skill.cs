using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG2
{
    public class Skill   //스킬 클래스 생성
    {
        public string Name { get; set; }
        public int UseMp { get; set; } //필요한 마나

        public int MultiAtk { get; set; }  //공격력의 몇배

        public int AtkNumber { get; set; }  //공격 횟수

        public Skill(string name, int usemp, int multiatk, int atknumber)
        {
            Name = name;
            UseMp = usemp;
            MultiAtk = multiatk;
            AtkNumber = atknumber;

        }


    }
}
