using System.Threading;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System;

namespace SpartaTextRPG2
{
    internal class Program
    {
        private static Character player;
        private static Monster[] monsters; // 몬스터 종류
        private static Monster[] ranMonsters; // 랜덤 몬스터 저장하는 배열
        static Random ran = new Random();

        static List<Skill> skills = new List<Skill>();  //스킬을 담는 리스트 생성
        static bool isUseSkill = false;   //스킬활성화
        static int skillSelect; //스킬선택

        static int dungeonLevel;
        static Save save = new Save(); //저장파일 생성

        private static List<Item> invenList = new List<Item>(); // 인벤토리 아이템 생성
        static Potion potion = new Potion(); //포션생성

        static void Main(string[] args)
        {
            GameDataSetting();
            //CreatePlayer();
            DisplayGameIntro();

        }

        static void GameDataSetting()
        {

            // 캐릭터 정보 세팅
            CreatePlayer(); // 이름 입력과 직업 선택 화면


            // 몬스터 정보 세팅 => 몬스터 생성도 CreateMonster 하나 만들자

            monsters = new Monster[5] { CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster() };
            //monsters = new Monster[3] { monster1, monster2, monster3 };
            ranMonsters = new Monster[ran.Next(1, 4)];

            // 스킬 정보 세팅(스킬담은 리스트) //전사
            

            

            //궁수
            






            for (int i = 0; i < ranMonsters.Length; i++) // ※ 랜덤 마릿수(ranMonsters.Length)의 랜덤 몬스터(y)를 생성
            {
                /*int y = ran.Next(0, 2);

                switch (y)
                {
                    case 0:
                        ranMonsters[i] = new Monster("미니언", 2, 15, 15, 5, false);   //랜덤 정수 y가 0이면 '미니언' 몬스터 생성
                        break;
                    case 1:
                        ranMonsters[i] = new Monster("대포미니언", 5, 25, 25, 8, false); //랜덤 정수 y가 1이면 '대포미니언' 몬스터 생성
                        break;
                    case 2:
                        ranMonsters[i] = new Monster("공허충", 3, 10, 10, 9, false);   //랜덤 정수 y가 2이면 '공허충' 몬스터 생성
                        break;
                }*/
                ranMonsters[i] = monsters[i];
            }
        }


        //--------------------------------------------------------------전투 상황 화면----------------------------------------------------------------

        // 1. 게임 첫 시작 화면 
        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("이제 전투를 시작할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine($"2. 전투시작 (현재 진행 : {dungeonLevel}층)");
            Console.WriteLine("3. 인벤토리");
            Console.WriteLine("4. 저장하기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 4);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayBattle();
                    break;
                case 3:
                    DisplayInventory();
                    break;
                case 4:
                    save.SaveInformation(player, potion, invenList, dungeonLevel);   //저장할 파일 담기
                    var preuser = JObject.FromObject(save); //파일 저장
                    Console.WriteLine(preuser.ToString());
                    Thread.Sleep(2000);
                    File.WriteAllText(@"../SpartaTextRPG2.json", preuser.ToString());
                    //File.WriteAllText(@"C:\Users\82106\Documents\GitHub\2-1teamproject\SpartaTextRPG2.json", preuser.ToString());
                    DisplayGameIntro();
                    break;
            }
        }

        // 1-1. 캐릭터 상태 보기 화면
        static void DisplayMyInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태보기");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.MaxHealth} | {player.CurHealth} ");
            Console.WriteLine($"마나 : {player.MaxMp}  | {player.CurMp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        // 1-2. 전투 시작 화면
        static void DisplayBattle() // 전투 페이지, 적 정보와 나의 정보를 알려주고 공격할지 도망갈지 선택할 수 있음
        {

            // 공격할 몬스터 번호를 선택
            // 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Battle!!");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[몬스터 종류]");
            Console.ResetColor();

            for (int i = 0; i < ranMonsters.Length; i++)
            {
                Console.WriteLine($"Lv.{ranMonsters[i].Level} {ranMonsters[i].Name} HP {ranMonsters[i].CurHealth} \n");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[내 정보]");
            Console.ResetColor();
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.CurHealth} / {player.MaxHealth}");
            Console.WriteLine($"마나 : {player.CurMp} / {player.MaxMp}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 공격");
            // Console.WriteLine("2. 스킬");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    DisplayBattleInfo();
                    break;

                default:

                    break;
            }
        }

        // 2-1. 전투 스킬 사용 화면
        static void DisplayBattleInfo()
        {

            // 공격할 몬스터 번호를 선택 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Battle!!");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[몬스터 종류]");
            Console.ResetColor();

            for (int i = 0; i < ranMonsters.Length; i++)
            {
                if (ranMonsters[i].IsDead == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{i + 1} ");
                    Console.WriteLine($"Lv.{ranMonsters[i].Level} {ranMonsters[i].Name} Dead"); //몬스터 체력 0 이하면 Dead 출력
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{i + 1} ");
                    Console.WriteLine($"Lv.{ranMonsters[i].Level} {ranMonsters[i].Name} HP {ranMonsters[i].CurHealth} \n");
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[내 정보]");
            Console.ResetColor();
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.CurHealth} / {player.MaxHealth}");
            Console.WriteLine($"마나 : {player.CurMp} / {player.MaxMp}");
            Console.WriteLine();
            //스킬출력
            if (isUseSkill == false)  //만약 스킬활성화가 아니면 isUseSkill => 
            {
                Console.WriteLine("스킬을 사용하시겠습니까?");   //물어보기
                Console.WriteLine("0. 취소");
                Console.WriteLine("1. 공격한다");
                Console.WriteLine("2. 스킬사용");
                Console.WriteLine("3. 포션 마시기");

                int inp = CheckValidInput(0, 3);
                switch (inp)
                {
                    case 0:
                        DisplayBattleInfo();
                        break;
                    case 1:
                        isUseSkill = false;
                        break;
                    case 2:
                        isUseSkill = true;
                        break;
                    case 3:
                        DrinkPotion();
                        break;
                }
            }
            if (isUseSkill == true)                               //스킬이 활성화면
            {
                int i = 1;
                foreach (Skill skill in skills)                   //skills리스트에 있는 스킬들 출력
                {
                    Console.WriteLine($"{i} {skill.Name} - 사용마나{skill.UseMp}");
                    if (i == 3)
                    {
                        Console.WriteLine($"공격력의{skill.MultiAtk}배로 모든 적을 공격합니다.");

                    } else
                    {
                        Console.WriteLine($"공격력의{skill.MultiAtk}배로 무작위 {skill.AtkNumber}명의 적을 공격합니다.");

                    }
                    Console.WriteLine("");
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("스킬을 골라주세요");
                skillSelect = CheckValidInput(1, skills.Count);    //어떤스킬 사용할지 입력받기

                if (player.CurMp < skills[skillSelect - 1].UseMp)  //마나가 부족하면
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("마나가 부족합니다");
                    Console.ResetColor();
                    isUseSkill = false;                             //비활성화
                }
                else if (player.Level < 3 && skillSelect == 3) // 레벨이 3 미만이면서 3번 스킬을 선택한 경우
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("해당 스킬은 레벨 3 이상부터 사용할 수 있는 스킬입니다.");
                    Console.ResetColor();
                    isUseSkill = false; // 비활성화
                }
                else
                {
                    switch (skillSelect)
                    {
                        case 2:
                            DisplayAttack(0);

                            break;
                        case 3:
                            DisplayAttack(0);

                            break;
                        default :
                            break;
                    }
                }
                
            }

            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요");

            int input = CheckValidInput(0, ranMonsters.Length);
            switch (input)
            {
                case 0:
                    DisplayBattle();
                    break;

                default: //죽은놈 판별
                    if (ranMonsters[input - 1].IsDead == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("이미 죽은 몬스터입니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        DisplayBattleInfo(); //다시 선택해라

                    }
                    else
                    {
                        DisplayAttack(input);
                    }
                    break;
            }
        }


        // 실제 전투가 일어나는 페이지
        static void DisplayAttack(int inp)
        {
            // 공격 기능 
            // 공격 결과표시 화면
            // 공격 대상 판별
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            if (player.MyTurn == true) // 내 턴일때
            {
                int damage = 0;
                int sumskilldamage = 0;  //스킬데미지 종합
                int err = (int)Math.Ceiling(player.Atk / 10f); //int err = Math.Ceiling(player.Atk/10);
                int randomMonster;
                if (isUseSkill == true)  //스킬 활성화면
                {
                    damage = skills[skillSelect - 1].MultiAtk * ran.Next((int)Math.Round(player.Atk - err), (int)Math.Round(player.Atk + err));
                    Console.WriteLine($"{player.Name}의 {skills[skillSelect - 1].Name}!");
                    if (skills[skillSelect - 1].AtkNumber == 1) //단일공격 스킬
                    {

                        //공격
                        
                        Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}]");

                        Console.WriteLine();
                        Console.WriteLine($"{ranMonsters[inp - 1].Name}");

                        if ((ranMonsters[inp - 1].CurHealth - damage) <= 0)
                        {
                            Console.WriteLine($"HP {ranMonsters[inp - 1].CurHealth} -> Dead");
                            ranMonsters[inp - 1].CurHealth = 0;
                            ranMonsters[inp - 1].IsDead = true;
                        }
                        else
                        {
                            Console.WriteLine($"HP {ranMonsters[inp - 1].CurHealth} -> {ranMonsters[inp - 1].CurHealth - damage}");

                        }
                        ranMonsters[inp - 1].CurHealth -= damage; // 실제로 피해를 주는 코드
                    }
                    else if (skills[skillSelect-1].AtkNumber == 100) // 전체공격 스킬
                    {
                        foreach(Monster mons in ranMonsters)
                        {
                            if (mons.IsDead == false)
                            {
                                //공격
                                //sumskilldamage += damage;
                                Console.WriteLine($"{mons.Name}을(를) 맞췄습니다. [데미지 : {damage}]");
                                Console.WriteLine();
                                Console.WriteLine($"{mons.Name}");

                                if ((mons.CurHealth - damage) <= 0)
                                {
                                    Console.WriteLine($"HP {mons.CurHealth} -> Dead");
                                    mons.CurHealth = 0;
                                    mons.IsDead = true;
                                }
                                else
                                {
                                    Console.WriteLine($"HP {mons.CurHealth} -> {mons.CurHealth - damage}");

                                }
                                mons.CurHealth -= damage; // 실제로 피해를 주는 코드

                            }
                           
                        }
                    }
                    else // 다중공격 스킬
                    {
                        int y = 0;
                        for (int i = 0; i < skills[skillSelect - 1].AtkNumber; i++)  //공격횟수만큼 공격
                        {

                            randomMonster = ran.Next(0, ranMonsters.Length);
                            if (ranMonsters[randomMonster].IsDead == false)
                            {
                                //공격
                                //sumskilldamage += damage;
                                Console.WriteLine($"{ranMonsters[randomMonster].Name}을(를) 맞췄습니다. [데미지 : {damage}]");
                                Console.WriteLine();
                                Console.WriteLine($"{ranMonsters[randomMonster].Name}");

                                if ((ranMonsters[randomMonster].CurHealth - damage) <= 0)
                                {
                                    Console.WriteLine($"HP {ranMonsters[randomMonster].CurHealth} -> Dead");
                                    Console.WriteLine();
                                    ranMonsters[randomMonster].CurHealth = 0;
                                    ranMonsters[randomMonster].IsDead = true;
                                }
                                else
                                {
                                    Console.WriteLine($"HP {ranMonsters[randomMonster].CurHealth} -> {ranMonsters[randomMonster].CurHealth - damage}");

                                }
                                ranMonsters[randomMonster].CurHealth -= damage; // 실제로 피해를 주는 코드

                            }
                            else
                            {

                                i--;
                                y++;
                            }
                            if(y > 50)
                            {
                                break;
                            }

                        }
                    }
                    Console.WriteLine();
                    player.CurMp -= skills[skillSelect - 1].UseMp;
                    Console.WriteLine($"마나 {player.MaxMp} -> {player.CurMp} ");
                    player.MyTurn = false;
                    isUseSkill = false;

                }
                else //일반공격이면
                {
                    damage = ran.Next((int)Math.Round(player.Atk - err), (int)Math.Round(player.Atk + err));
                    bool isAtkUp = ran.Next(0, 100) < 15; // 15프로 확률
                    bool isDodgeAtk = ran.Next(0, 100) < 10; // 10프로 확률

                    Console.WriteLine($"{player.Name}의 공격!");
                    if (isDodgeAtk)
                    {
                        Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) 공격했지만 아무 일도 일어나지 않았습니다.");

                    }
                    else
                    {
                        if (isAtkUp)
                        {
                            damage = (int)Math.Round(damage * 1.6); // 치명타 데미지 160% 적용
                            Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}] - 치명타 공격!!");

                        }
                        else
                        {
                            Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}]");


                        }

                        Console.WriteLine();
                        Console.WriteLine($"{ranMonsters[inp - 1].Name}");

                        if ((ranMonsters[inp - 1].CurHealth - damage) <= 0)
                        {
                            Console.WriteLine($"HP {ranMonsters[inp - 1].CurHealth} -> Dead");
                            ranMonsters[inp - 1].CurHealth = 0;
                            ranMonsters[inp - 1].IsDead = true;
                        }
                        else
                        {
                            Console.WriteLine($"HP {ranMonsters[inp - 1].CurHealth} -> {ranMonsters[inp - 1].CurHealth - damage}");

                        }
                        ranMonsters[inp - 1].CurHealth -= damage; // 실제로 피해를 주는 코드
                        player.MyTurn = false;
                        isUseSkill = false;
                    }

                }




                int monDeadCount = 0; // true인 mon의 개수
                foreach (Monster mon in ranMonsters) // 살아있는 몬스터 전부 돌아가면서 공격
                {
                    if (mon.IsDead == false) // 살아있는 몬스터의 행동
                    {

                        Thread.Sleep(1000);
                        Console.WriteLine();
                        Console.WriteLine("Enemy turn"); // 적 턴 시작
                        Console.WriteLine();
                        Console.WriteLine("공격을 피하시겠습니까 ?");//공격 피할지 물어본다 
                        Console.WriteLine();
                        Console.WriteLine("1. 안피한다 .");
                        Console.WriteLine("2. 피한다 .");
                        Console.WriteLine();


                        int dodgerun = CheckValidInput(1, 2);
                        bool isrun = ran.Next(0, 100) < 50; 
                        if (dodgerun == 1)//1.안피한다 
                        {
                            Console.WriteLine("공격을 겸허히 받아들이는 중입니다 . ");
                        }
                        else if (dodgerun == 2 && isrun)//2.피한다>>50프로의 확률로 피한다 (541~542줄 )
                        {
                            Console.WriteLine("슉 -");
                            Console.WriteLine("슈슉 -");
                            Console.WriteLine($"{mon.Name}의 공격을 피하셨습니다 .");
                            continue;
                        }
                        if (mon.Boss == 0)
                        { // 일반 몬스터의 행동
                            mon.Damage = mon.Atk - (int)Math.Round(player.Def * (float)0.1);
                            Console.WriteLine($"Lv.{mon.Level} {mon.Name}의 공격!");
                            Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {mon.Damage}]");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine($"Lv.{player.Level} {player.Name}");
                            Console.WriteLine($"HP {player.CurHealth} -> {player.CurHealth - mon.Damage}");
                            player.CurHealth -= mon.Damage;
                            Console.WriteLine();


                        }
                        else //보스 행동
                        {
                            int skillNum = ran.Next(0, 4);

                            switch (mon.BossSkill(skillNum))
                            {
                                case 0:
                                    Console.WriteLine($"Lv.{mon.Level} {mon.Name}가  일반공격을 사용합니다!");
                                    Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {mon.Damage}]");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                                    Console.WriteLine($"HP {player.CurHealth} -> {player.CurHealth - mon.Damage}");
                                    player.CurHealth -= mon.Damage;
                                    break;
                                case 1:
                                    Console.WriteLine($"Lv.{mon.Level} {mon.Name}가  공격스킬을 사용합니다!");
                                    Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {mon.Damage}]");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                                    Console.WriteLine($"HP {player.CurHealth} -> {player.CurHealth - mon.Damage}");
                                    player.CurHealth -= mon.Damage;
                                    break;
                                case 2:
                                    Console.WriteLine($"Lv.{mon.Level} {mon.Name}가  회복스킬을 사용합니다!");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine($"{mon.Name}의 HP가 {mon.CurHealth}가 되었습니다.");
                                    break;
                                case 3:
                                    Console.WriteLine($"Lv.{mon.Level} {mon.Name}가  몬스터를 소환합니다!");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    if (ranMonsters.Length < 4)
                                    {
                                        Array.Resize(ref ranMonsters, ranMonsters.Length + 1);
                                        ranMonsters[ranMonsters.Length - 1] = new Monster("미니언1", 0, 15, 15, 5, false, 0);
                                    }
                                    else
                                    {
                                        Console.WriteLine("몬스터 수가 최대입니다. 몬스터가 소환되지 않습니다.");
                                    }
                                    break;
                            }

                            Console.WriteLine();


                            if (player.CurHealth <= 0)
                            {
                                DisplayLose();
                                break;
                            }
                        }
                    }

                    else // 죽어있는 몬스터의 행동
                    {

                        monDeadCount++;
                        // 결과값을 모두 저장할 배열
                        // 배열 검사해서 모두  true일 때 true 인 bool 변수 하나
                    }

                }
                player.MyTurn = true;

                if (monDeadCount == ranMonsters.Length)
                {
                    DisplayVictory();
                }

                Console.WriteLine("0. 다음"); // 0으로 넘어갈지 thread.sleep으로 시간차 두고 넘어갈지 정하기
            }
            else
            {
                Console.WriteLine("플레이어의 턴이 아닙니다.");
            }



            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayBattleInfo();
                    break;

                default:

                    break;
            }
        }

        // 전투 중 포션 사용
        static void DrinkPotion()
        {
            Console.Clear();
            Console.WriteLine("회복");
            Console.WriteLine($"체력포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : {Potion.hpPotionCount}  현재체력: {player.CurHealth}");
            Console.WriteLine($"마나포션을 사용하면 마나을 30 회복 할 수 있습니다. (남은 포션 : {Potion.mpPotionCount} 현재마나: {player.CurMp}");
            Console.WriteLine("");

            Console.WriteLine("0.나가기");
            Console.WriteLine("1.마나포션 사용하기");
            Console.WriteLine("2.체력포션 사용하기");
            

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayBattleInfo(); // 인벤토리 시작 화면
                    break;
                case 1:
                    potion.MpPotionUse(player); // 체력 포션
                    Thread.Sleep(1000);
                    DrinkPotion();
                    break;
                case 2:
                    potion.HpPotionUse(player); // 마나 포션
                    Thread.Sleep(1000);
                    DrinkPotion();
                    break;
            }
        }

        //----------------------------------------------------------전투 결과(레벨업 정보)------------------------------------------------------------

        // 승리
        private static void DisplayVictory()
        {
            // 클리어 후 사냥한 몬스터만큼 경험치 증가
            // 1~2는 10 필요, 2~3은 35필요, 3~4는 65, 4~5는 100, 만렙은 5이며 exp증가 X
            // 레벨업 시 기본 공격력 + 0.5, 방어력 + 1
            // 몬스터 레벨 1당 1의 경험치 제공
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Victory");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"던전에서 몬스터 {ranMonsters.Length}마리를 잡았습니다.");

            Console.WriteLine();
            Console.WriteLine("[캐릭터 정보]");

            int getExp = 0;
            foreach (Monster mon in ranMonsters)
            {
                getExp += mon.Level;
            }

            if ((player.Exp + getExp) > player.TotalExp) //레벨업 검사
            {
                Console.WriteLine($"Lv.{player.Level} {player.Name} -> Lv.{player.Level + 1} {player.Name}");

            }
            else
            {
                Console.WriteLine($"Lv.{player.Level} {player.Name} -> {player.Level} {player.Name}");

            }
            Console.WriteLine($"HP {player.MaxHealth} -> {player.CurHealth} ");

            Console.Write($"EXP {player.Exp} -> ");
            player.Exp += getExp;
            if ((player.Exp) >= player.TotalExp) //레벨업 검사
            {
                player.LevelUp();   //레벨업 
                Console.WriteLine($"{player.Exp}");
            }
            else
            {
                Console.WriteLine($"{player.Exp} ");
            }
            Console.WriteLine();
            Console.WriteLine("[획득 아이템]");

            int itemCount = ran.Next(1, ranMonsters.Length);
            for (int i = 0; i < itemCount; i++)
            {
                int IsPotionGet = ran.Next(1, 10);            //포션 확률적으로 얻기
                if (6 > IsPotionGet)  //50%확룰로 포션획득
                {
                    Console.WriteLine("체력포션 획득");
                    Potion.hpPotionCount++;
                }
                else
                {
                    Console.WriteLine("마나포션 획득");
                    Potion.mpPotionCount++;
                }
                Item droppedItem = DropItem(); // 아이템 생성
                Console.WriteLine(droppedItem.Name);
                // Console.WriteLine(droppedItem.Name);    //드롭될 아이템을 생성(new)하고 그 이름을 출력
                DropeItemToInventory(droppedItem); // 아이템 인벤토리에 추가
            }

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            dungeonLevel += 1;
            monsters = new Monster[5] { CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster() }; // 몬스터가 다 죽으면 새로운 몬스터를 생성하는 코드
            if (dungeonLevel >= 4)
            {
                ranMonsters = new Monster[1];
            }
            else
            {
                switch (dungeonLevel)// 던전 레벨에 따라 몬스터 마리수를 무작위로 생성
                {
                    case 1:
                        ranMonsters = new Monster[ran.Next(1, 4)];
                        break;
                    case 2:
                        ranMonsters = new Monster[ran.Next(2, 4)];
                        break;
                    case 3:
                        ranMonsters = new Monster[ran.Next(3, 5)];
                        break;
                    default:
                        ranMonsters = new Monster[ran.Next(1, 4)];
                        Console.WriteLine("다음 스테이지는 보스 스테이지입니다.");
                        break;
                }
            }
            for (int i = 0; i < ranMonsters.Length; i++)
            {
                ranMonsters[i] = monsters[i];
            }

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        // 패배
        private static void DisplayLose()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Lose");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            if (player.CurHealth <= 0)
            {
                player.CurHealth = 0;
            }
            Console.WriteLine($"HP {player.MaxHealth} -> {player.CurHealth} ");

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            player.CurHealth = player.MaxHealth;
            player.CurMp = player.MaxMp;

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }



        //-------------------------------------------------------------인벤토리-------------------------------------------------------------------------

        // 1-3 인벤토리 화면
        static void DisplayInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 포션과 아이템들을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 포션 관리 \n2. 아이템 관리 \n0. 나가기");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayGameIntro(); // 시작 화면
                    break;
                case 1:
                    DisPlayPotion(); // 포션 관리
                    break;
                case 2:
                    DisPlayItem(); // 아이템 관리
                    break;
            }
        }

        static void DisPlayPotion()
        {
            Console.Clear();
            Console.WriteLine("회복");
            Console.WriteLine($"체력포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : {Potion.hpPotionCount}  현재체력: {player.CurHealth}");
            Console.WriteLine($"마나포션을 사용하면 마나을 30 회복 할 수 있습니다. (남은 포션 : {Potion.mpPotionCount} 현재마나: {player.CurMp}");
            Console.WriteLine("");

            Console.WriteLine("0.나가기");
            Console.WriteLine("1.마나포션 사용하기");
            Console.WriteLine("2.체력포션 사용하기");
            

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayInventory(); // 인벤토리 시작 화면
                    break;
                case 1:
                    potion.MpPotionUse(player); // 체력 포션
                    Thread.Sleep(1000);
                    DisPlayPotion();
                    break;
                case 2:
                    potion.HpPotionUse(player); // 마나 포션
                    Thread.Sleep(1000);
                    DisPlayPotion();
                    break;
            }
        }

        static void DisPlayItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            string e;
            foreach (var item in invenList)
            {
                e = item.PlayerEquipped ? "[E]" : "[X]";
                Console.WriteLine($"{e} {item.Name,-5}|{item.Type}(+{item.Power,-3})|{item.Description,-20}");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 장착 관리 \n2. 아이템 정렬 \n0. 나가기");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayInventory(); // 인벤토리 시작 화면
                    break;
                case 1:
                    EquipManagment(); // 장착 관리
                    break;
                case 2:
                    InventoryArray(); // 문자열 정렬
                    break;
            }
        }

        // 장착 관리 : 현재의 장착상태를 보여줌
        static void EquipManagment()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 아이템에 대해 장착여부를 관리할 수 있습니다.");
            Console.WriteLine("[E]:장착무기, [X]:해제무기 ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string e;
            foreach (var item in invenList)
            {
                i++; // 목록 앞 숫자
                e = item.PlayerEquipped ? "[E]" : "[X]";
                Console.WriteLine($"{i}. {e} {item.Name,-5}|{item.Type}(+{item.Power,-3})|{item.Description,-20}");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("장착 또는 해제하고 싶다면 아이템 앞 번호를 입력해주세요. \n화면에서 나가려면 0번을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, invenList.Count);
            if (input == 0) // 0.나가기
            {
                DisPlayItem(); // 아이템 관리 화면
                return;
            }
            else
            {
                if (invenList[input - 1].PlayerEquipped)
                {
                    // 장착 상태 변경 E -> X(true -> false)
                    invenList[input - 1].PlayerEquipped = false;

                    // 공격 아이템이면 공격력 감소, 방어 아이템이면 방어력 감소
                    if (invenList[input - 1].Type == "공격력")
                    {
                        player.Atk -= invenList[input - 1].Power;
                    }
                    else if (invenList[input - 1].Type == "방어력")
                    {
                        player.Def -= invenList[input - 1].Power;
                    }
                }
                else if (!invenList[input - 1].PlayerEquipped)
                {
                    // 장착 상태 변경 X -> E(false -> true)
                    invenList[input - 1].PlayerEquipped = true;

                    // 공격 아이템이면 공격력 증가, 방어 아이템이면 방어력 증가
                    if (invenList[input - 1].Type == "공격력")
                    {
                        player.Atk += invenList[input - 1].Power;
                    }
                    else if (invenList[input - 1].Type == "방어력")
                    {
                        player.Def += invenList[input - 1].Power;
                    }

                }
            }
            EquipManagment();
        }

        // 아이템 정렬: 이름, 장착, 공격, 방어순
        static void InventoryArray()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 아이템 정렬");
            Console.ResetColor();
            Console.WriteLine("보유 아이템들의 순서를 정렬해 볼 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string e;
            foreach (var item in invenList)
            {
                i++; // 목록 앞 숫자
                e = item.PlayerEquipped ? "[E]" : "[X]";
                Console.WriteLine($"{i}.{e} {item.Name,-5}|{item.Type}(+{item.Power})|가격 {item.Price,-3} G|{item.Description,-20}");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 이름\n2. 장착순\n3. 공격력\n4. 방어력 \n0. 나가기");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 4);
            switch (input)
            {
                case 0: // 나가기
                    DisPlayItem(); // 아이템 화면
                    break;

                case 1: // 이름 정렬
                    invenList = invenList.OrderByDescending(x => x.Name.Length).ToList();
                    InventoryArray();
                    break;

                case 2: // 장착순
                    invenList = invenList.OrderByDescending(x => x.PlayerEquipped).ToList();
                    InventoryArray();
                    break;
                case 3: // 공격력
                    invenList = invenList.OrderByDescending(x => x.Type == "공격력").ThenBy(x => x.Power).ToList();
                    InventoryArray();
                    break;
                case 4: // 방어력
                    invenList = invenList.OrderByDescending(x => x.Type == "방어력").ThenBy(x => x.Power).ToList();
                    InventoryArray();
                    InventoryArray();
                    break;
            }
        }

        static Item DropItem()  // ※ 나중엔 인벤토리에 저장해야할 듯
        {
            int itemIndex = 0;
            itemIndex = ran.Next(1, 4);
            switch (itemIndex)
            {
                /*case 1:
                    Potion.hpPotionCount++;
                    return new Item("체력포션");
                    break;*/
                case 1:
                    return new Item("낡은 검", "공격력", 3f, "쉽게 볼 수 있는 낡은 검 입니다.", false, "dropitem");
                //break;
                case 2:
                    return new Item("낡은 활", "공격력", 4f, "신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.", false, "dropitem");
                //break;
                case 3:
                    return new Item("낡은 스태프", "방어력", 2f, "적의 공격으로부터 보호를 제공하는 동시에 주문력을 발휘할 수 있는 스태프입니다.", false, "dropitem");
                    //break;
                    /*case 5:
                        return new Item("500G");
                    case 6:
                        Potion.mpPotionCount++;
                        return new Item("마나포션");*/
            }

            return new Item("돌맹이", "공격력", 4, "원거리에서는 투척하여 적에게 공격을 가하는 방식으로 사용되는 돌멩이입니다.", false, "dropitem");
        }

        // 인벤토리 목록 추가
        static void DropeItemToInventory(Item item)
        {
            invenList.Add(item);
        }

        //----------------------------------------------------------입력 필터 함수-----------------------------------------------------------------------

        static int CheckValidInput(int min, int max)  //사용자로부터 입력받고 입력받은 값이 매개변수 사이의 값이 아니면 다시 입력받음
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }


        //-----------------------------------------------------플레이어 직업과 몬스터 종류-------------------------------------------------------------------

        // 플레이어 직업
        enum JobType
        {
            None = 0,
            Worrior = 1,
            Archer = 2,
            Mage = 3
        }

        static JobType ChooseJob()
        {
            JobType choice = JobType.None;
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 궁수");
            Console.WriteLine("3. 마법사");

            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    choice = JobType.Worrior;
                    break;
                case 2:
                    choice = JobType.Archer;
                    break;
                case 3:
                    choice = JobType.Mage;
                    break;
            }
            return choice;
        }

        static void CreatePlayer()

        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("♣ 스파르타 던전에 오신 여러분 환영합니다. ♣");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("저번 캐릭터를 이어하시겠습니까?");
            Console.WriteLine("1. 저번 캐릭터 이어하기");
            Console.WriteLine("2. 새로하기");
            Console.WriteLine();

            int input = CheckValidInput(1, 2);


            if (input == 1)
            {
                //if (File.ReadAllText(@"C:\Users\82106\Documents\GitHub\2-1teamproject\SpartaTextRPG2.json") == null)
                if (File.ReadAllText(@"../SpartaTextRPG2.json") == null)
                {
                    Console.WriteLine("저장하신 캐릭터가 없습니다.");
                    CreatePlayer();
                }
                else
                {
                    //var curuser = File.ReadAllText(@"C:\Users\82106\Documents\GitHub\2-1teamproject\SpartaTextRPG2.json");
                    var curuser = File.ReadAllText(@"../SpartaTextRPG2.json");
                    Save save2 = JsonConvert.DeserializeObject<Save>(curuser);
                    save = save2;
                    player = save.character;
                    potion = save.potion;
                    invenList = save.saveItems;
                    Potion.mpPotionCount = save.MpCount;
                    Potion.hpPotionCount = save.HpCount;
                    dungeonLevel = save.saveDungeonLevel;
                    Console.WriteLine($"{player.Name}님 환영합니다");
                    Thread.Sleep(1000);
                }

            }
            else
            {
                // 이름 설정
                Console.Write("이름을 설정해주세요:");
                string userName = Console.ReadLine();
                Console.WriteLine();

                dungeonLevel = 1;

                // 아이템 세팅(인벤토리)
                invenList.Add(new Item("무쇠갑옷", "방어력", 3.0f, "무쇠로 만들어져 튼튼한 갑옷입니다.", true, "player"));
                invenList.Add(new Item("불타는도끼", "공격력", 1.0f, "불꽃으로 베어내며 화염 공격을 가하는 도끼입니다.", false, "player"));

                JobType choice = ChooseJob();

                switch (choice)
                {
                    case JobType.Worrior:
                        player = new Character(userName, "전사", 1, 80, 10, 10000, 500, 500, 0, 10, 150, 150, true);
                        Skill skill1 = new Skill("알파 스트라이크", 10, 2, 1);
                        Skill skill2 = new Skill("더블 스트라이크", 15, 2, 2);
                        Skill skill3 = new Skill("고무고무 피스톨", 45, 99, 100);

                        skills.Add(skill1);
                        skills.Add(skill2);
                        skills.Add(skill3);
                        break;
                    case JobType.Archer:
                        player = new Character(userName, "궁수", 1, 10, 5, 10000, 120, 120, 0, 10, 50, 50, true);
                        Skill skill4 = new Skill("에궁", 5, 4, 1);
                        Skill skill5 = new Skill("이궁", 25, 2, 2);
                        Skill skill6 = new Skill("어이쿵", 45, 99, 100);

                        skills.Add(skill4);
                        skills.Add(skill5);
                        skills.Add(skill6);

                        break;
                    case JobType.Mage:
                        player = new Character(userName, "마법사", 1, 5, 5, 10000, 100, 100, 0, 10, 120, 120, true);
                        Skill skill7 = new Skill("지팡이로 때리기", 20, 4, 1);
                        Skill skill8 = new Skill("지팡이로 휘두르기", 25, 2, 2);
                        Skill skill9 = new Skill("옆집할아버지의 지팡이!!!!!", 45, 99, 100);

                        skills.Add(skill7);
                        skills.Add(skill8);
                        skills.Add(skill9);
                        break;
                }
                Console.WriteLine($"{player.Name}, {player.Job}를 생성합니다.");
                Thread.Sleep(1000);

            }

        }

        // 몬스터 종류
        enum MonsterType
        {
            None = 0,
            미니언 = 1,
            대포미니언 = 2,
            공허충 = 3,
            바선생 = 4,
            귀멸의강낭콩 = 5,
            보스몬스터 = 6
        }

        static MonsterType ChooseMonster()
        {
            MonsterType mon = MonsterType.None;

            int input = 0;
            switch (dungeonLevel) // 스테이지가 3개뿐이라 switch문 사용, 훨씬 많아지면 if로 하는게 좋음
            {
                case 1:
                    input = ran.Next(1, 4);
                    break;
                case 2:
                    input = ran.Next(2, 5);
                    break;
                case 3:
                    input = ran.Next(3, 6);
                    break;
                case 4:
                    input = 6; // ※ 마지막 스테이지에서 항상 보스가 나오게 하기
                    break;
                default:
                    input = ran.Next(1, 3);
                    break;
            }
            switch (input)
            {
                case 1:
                    mon = MonsterType.미니언;
                    break;
                case 2:
                    mon = MonsterType.대포미니언;
                    break;
                case 3:
                    mon = MonsterType.공허충;
                    break;
                case 4:
                    mon = MonsterType.바선생;
                    break;
                case 5:
                    mon = MonsterType.귀멸의강낭콩;
                    break;
                case 6:
                    mon = MonsterType.보스몬스터;
                    break;
            }
            return mon;
        }
        static Monster CreateMonster()  //몬스터를 랜덤으로 생성
        {
            MonsterType mon = ChooseMonster();

            switch (mon)
            {
                case MonsterType.미니언:
                    return new Monster("미니언", 2, 15, 15, 5, false, 0);
                    break;
                case MonsterType.대포미니언:
                    return new Monster("대포미니언", 5, 25, 25, 8, false, 0);
                    break;
                case MonsterType.공허충:

                    return new Monster("공허충", 3, 10, 10, 9, false, 0);
                    break;
                case MonsterType.바선생:
                    return new Monster("바선생", 7, 20, 20, 10, false, 0);
                    break;
                case MonsterType.귀멸의강낭콩:
                    return new Monster("귀멸의강낭콩", 10, 25, 25, 10, false, 0);
                    break;
                case MonsterType.보스몬스터:
                    return new Monster("보스몬스터", 50, 500, 500, 50, false, 1);
                    break;

                default:
                    return new Monster("미니언", 2, 15, 15, 5, false, 0);
                    break;
            }
        }
    }

}