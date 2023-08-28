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
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("민열", "전사", 1, 10, 5, 100, 15000, 100, 100, true);
            
            // 아이템 정보 세팅 => 상점에서 골드 대신 판매 완료를 하려면 어떻게 할까


            Monster monster1 = new Monster("미니언", 2, 15, 15, 5, false);
            Monster monster2 = new Monster("대포미니언", 5, 25, 25, 8, false);
            Monster monster3 = new Monster("공허충", 3, 10, 10, 9, false);
            monsters = new Monster[3] {monster1, monster2, monster3 };
            ranMonsters = new Monster[ran.Next(1, 4)];


            for (int i = 0; i < ranMonsters.Length; i++) // ※ 1~4마리의 몬스터가 랜덤하게 등장하도록 해야함, 표시 순서는 랜덤, 중복 가능
            {
                int y = ran.Next(0, 2);
                
                switch(y)
                {
                    case 0:
                        ranMonsters[i] = new Monster("미니언", 2, 15, 15, 5, false);
                        break;
                    case 1:
                        ranMonsters[i] = new Monster("대포미니언", 5, 25, 25, 8, false); ;
                        break;
                    case 2:
                        ranMonsters[i] = new Monster("공허충", 3, 10, 10, 9, false);
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

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
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


        static void DisplayBattle()
        {

            // 공격할 몬스터 번호를 선택
            // 
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            Console.WriteLine("[몬스터 종류]");




            for(int i = 0; i < ranMonsters.Length; i++)
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
        static void DisplayEnd()
        {

        }

        static void DisplayBattleInfo()
        {

            // 공격할 몬스터 번호를 선택
            // 
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            Console.WriteLine("[몬스터 종류]");

            for (int i = 0; i < ranMonsters.Length; i++)
            {
                Console.Write($"{i + 1} ");
                if (ranMonsters[i].IsDead == true)
                {
                    Console.WriteLine($"Lv.{ranMonsters[i].Level} {ranMonsters[i].Name} Dead"); //몬스터 체력 0 이하면 Dead 출력

                }
                else
                {
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

                default:

                    DisplayAttack(input);
                    break;
            }
        }
        /*static void DisplayEnd()
        {

        }*/
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

                int err = (int)Math.Ceiling(player.Atk / 10f);
                //int err = Math.Ceiling(player.Atk/10);
                int damage = ran.Next(player.Atk - err, player.Atk + err);

                Console.WriteLine($"{player.Name}의 공격!");
                Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}]"); // 데미지는 공격력의 10%의 오차값 랜덤으로, 오차가 소수점이라면 올림 처리, 콘솔 텍스트 색 변경법 알아보기
                Console.WriteLine();
                Console.WriteLine($"{ranMonsters[inp - 1].Name}");



                if ((ranMonsters[inp - 1].CurHealth - damage) <= 0) // curHealth가 이미 닳아있는 오류 있음
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

                Thread.Sleep(1500);

                foreach (Monster mon in ranMonsters) // 살아있는 몬스터 전부 돌아가면서 공격
                {
                    if (mon.IsDead == false)
                    {
                        Console.WriteLine($"Lv.{mon.Level} {mon.Name}의 공격!");


                        Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {mon.Atk}]");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Lv.{player.Level} {player.Name}");
                        Console.WriteLine($"HP {player.CurHealth} -> {player.CurHealth - mon.Atk}");
                        player.CurHealth -= mon.Atk;
                        Console.WriteLine();

                    }
                    else
                    {
                        // 몬스터가 다 죽었을 때
                    }
                    if (player.CurHealth <= 0)
                    {
                        // DisplayGameOver(); 플레이어 체력이 0 이하면 게임종료 실행
                        break;
                    }

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
        static void DisplayGameOver()
        {

            if (player.CurHealth > 0 && player.CurHealth <= player.MaxHealth)
            {
                DisplayVictory();
            }
            else if (player.CurHealth == 0)
            {
                DisplayLose();
            }

        }

        private static void DisplayVictory()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Battle!! - Result");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Victory");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.");

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
    }


    public class Character  // 캐릭터 정보를 담당하는 클래스
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public float Gold { get; set; }
        public int CurHealth { get; set; }
        public int MaxHealth { get; set; }

        public bool MyTurn { get; set; }

        public Character(string name, string job, int level, int atk, int def, int hp, float gold, int curHealth, int maxHealth, bool myTurn)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            CurHealth = curHealth;
            MaxHealth = maxHealth;
            MyTurn = myTurn;
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
            isDead = isDead;
        }
    }
}