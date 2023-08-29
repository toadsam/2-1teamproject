
namespace SpartaTextRPG2
{
    internal class Program
    {
        private static Character player;
        private static Monster[] monsters; // 몬스터 종류
        private static Monster[] ranMonsters; // 랜덤 몬스터 저장하는 배열
        static Random ran = new Random();

        static void Main(string[] args)
        {
            GameDataSetting();
            //CreatePlayer();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {

            // 캐릭터 정보 세팅
            CreatePlayer();
            // 이름 설정 
            Console.Write("이름을 설정해주세요:");

            string UserName = Console.ReadLine();

            Console.WriteLine("안녕하세요!" + "UserName" + "님!");

            // 몬스터 정보 세팅 => 몬스터 생성도 CreateMonster 하나 만들자
            Monster monster1 = new Monster("미니언", 2, 15, 15, 5, false);
            Monster monster2 = new Monster("대포미니언", 5, 25, 25, 8, false);
            Monster monster3 = new Monster("공허충", 3, 10, 10, 9, false);
            monsters = new Monster[3] { monster1, monster2, monster3 };
            ranMonsters = new Monster[ran.Next(1, 4)];  // 무작위 몬스터 생성(1마리 ~ 4마리)

            for (int i = 0; i < ranMonsters.Length; i++) // ※ 랜덤 마릿수(ranMonsters.Length)의 랜덤 몬스터(y)를 생성
            {
                int y = ran.Next(0, 2);

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
                }
            }
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 전투시작");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayBattle();
                    break;
            }
        }

        static void DisplayMyInfo() //캐릭터 상태창
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.MaxHealth}");
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


        static void DisplayBattle() // 전투 페이지, 적 정보와 나의 정보를 알려주고 공격할지 도망갈지 선택할 수 있음
        {

            // 공격할 몬스터 번호를 선택
            // 
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[몬스터 종류]");

            for (int i = 0; i < ranMonsters.Length; i++)
            {
                Console.WriteLine($"Lv.{ranMonsters[i].Level} {ranMonsters[i].Name} HP {ranMonsters[i].CurHealth} \n");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.CurHealth} / {player.MaxHealth}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 공격");
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

        static void DisplayBattleInfo()
        {

            // 공격할 몬스터 번호를 선택 
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            Console.WriteLine("[몬스터 종류]");

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
            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.CurHealth} / {player.MaxHealth}");
            Console.WriteLine();
            Console.WriteLine("0. 취소");
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
                        Console.WriteLine("이미 죽은 몬스터입니다.");
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

        static void DisplayAttack(int inp) // 실제 전투가 일어나는 페이지
        {
            // 공격 기능 
            // 공격 결과표시 화면
            // 공격 대상 판별
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            if (player.MyTurn == true) // 내 턴일때
            {

                float err = (float)Math.Ceiling(player.Atk / 10f);
                //int err = Math.Ceiling(player.Atk/10);
                int damage = ran.Next((int)Math.Round(player.Atk - err), (int)Math.Round(player.Atk + err)); // 레벨업 시 플레이어 공격력이 0.5씩 오르기 때문에 타입 오류가 생기는걸 방지하기 위해 Round함수 적용

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
                        // 데미지는 공격력의 10%의 오차값 랜덤으로, 오차가 소수점이라면 올림 처리, 콘솔 텍스트 색 변경법 알아보기

                    }

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

                Thread.Sleep(1000);

                Console.WriteLine("Enemy turn");

                int monDeadCount = 0; // true인 mon의 개수
                foreach (Monster mon in ranMonsters) // 살아있는 몬스터 전부 돌아가면서 공격
                {

                    if (mon.IsDead == false) // 살아있는 몬스터의 행동
                    {
                        Console.WriteLine($"Lv.{mon.Level} {mon.Name}의 공격!");

                        Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {mon.Atk}]");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Lv.{player.Level} {player.Name}");
                        Console.WriteLine($"HP {player.CurHealth} -> {player.CurHealth - mon.Atk}");
                        player.CurHealth -= mon.Atk;
                        Console.WriteLine();

                        if (player.CurHealth <= 0)
                        {
                            DisplayLose();
                            break;
                        }
                    }
                    else // 죽어있는 몬스터의 행동
                    {

                        monDeadCount++;
                        // 결과값을 모두 저장할 배열
                        // 배열 검사해서 모두  true일 때 true 인 bool 변수 하나
                    }

                }
                if (monDeadCount == ranMonsters.Length)
                {
                    DisplayVictory();
                }
                player.MyTurn = true;

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


        static int CheckValidInput(int min, int max)    //사용자로부터 입력받고 입력받은 값이 매개변수 사이의 값이 아니면 다시 입력받음
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


        // 윤경: 전투 결과
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
            if ((player.Exp + getExp) > player.TotalExp) //레벨업 검사
            {

                player.LevelUp();   //레벨업 
                Console.WriteLine($"{player.Exp}");
                Console.WriteLine($"{player.TotalExp}");

            }
            else
            {
                Console.WriteLine($"{player.Exp + getExp} ");

            }

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }


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
            Console.WriteLine($"HP {player.MaxHealth} -> {player.CurHealth} ");

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

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
            JobType choice = ChooseJob();

            switch (choice)
            {
                case JobType.Worrior:
                    player = new Character("플레이어", "전사", 1, 5, 10, 70, 10000, 150, 150, 0, 10, true);
                    break;
                case JobType.Archer:
                    player = new Character("플레이어", "궁수", 1, 10, 5, 70, 10000, 120, 120, 0, 10, true);
                    break;
                case JobType.Mage:
                    player = new Character("플레이어", "마법사", 1, 8, 5, 120, 10000, 100, 100, 0, 10, true);
                    break;
            }

        }
    }


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

        public bool MyTurn { get; set; }

        public Character(string name, string job, int level, float atk, int def, int mp, float gold, int curHealth, int maxHealth, int exp, int totalExp, bool myTurn)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Mp = mp;
            Gold = gold;
            CurHealth = curHealth;
            MaxHealth = maxHealth;
            Exp = exp;
            TotalExp = totalExp;
            MyTurn = myTurn;
        }

        public void LevelUp()
        {
            Atk += 0.5f;             // 레벨업 시 기본 공격력 + 0.5, 방어력 + 1
            Def += 1;
            Exp = Exp - TotalExp;
            Level++;
            TotalExp += (20 + (Level - 1) * 5);         // 1는 10 필요, 2~3은 35필요, 3~4는 65, 4~5는 100, 만렙은 5이며 exp증가 X
                                                        //레벨업은 player.Level++ / totalExp를 그에 맞게 올림 / totalExp는 += 20 + (level-1)*5(레벨이 2 이상이면)
        }
    }

    public class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }
        public int CurHealth { get; set; }
        public int Atk { get; set; }

        public bool IsDead { get; set; }




        public Monster(string name, int level, int maxHealth, int curHealth, int atk, bool isDead)
        {
            Name = name;
            Level = level;
            MaxHealth = maxHealth;
            CurHealth = curHealth;
            Atk = atk;
            IsDead = isDead;
        }
    }

}