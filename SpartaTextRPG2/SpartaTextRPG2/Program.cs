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
        //static Potion potion = new Potion();


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
            Monster monster1 = CreateMonster();
            Monster monster2 = CreateMonster();
            Monster monster3 = CreateMonster();
            Monster monster4 = CreateMonster();

            monsters = new Monster[4] { CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster() };
            //monsters = new Monster[3] { monster1, monster2, monster3 };
            ranMonsters = new Monster[ran.Next(1, 4)];  // 무작위 몬스터 생성(1마리 ~ 4마리)
            Skill skill1 = new Skill("알파 스트라이크", 10, 2, 1);
            Skill skill2 = new Skill("더블 스트라이크", 15, 2, 2);
            Skill skill3 = new Skill("고무고무 피스톨", 45, 99, 9);
            //스킬담는 리스트
            skills.Add(skill1);
            skills.Add(skill2);
            skills.Add(skill3);
           
           
            
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
                    case 3:
                        ranMonsters[i] = new Monster("바선생", 7, 20, 20, 10, false);   //랜덤 정수 y가 3이면 '바선생' 몬스터 생성
                        break;
                    case 4:
                        ranMonsters[i] = new Monster("귀멸의강낭콩", 10, 25, 25, 10, false);   //랜덤 정수 y가 4이면 '귀멸의강낭콩' 몬스터 생성
                         break;
                }*/
                ranMonsters[i] = monsters[i];
            }
        }


//----------------------------------------------------------전투 상황 화면-----------------------------------------------------------------------
        
        // 1. 게임 첫 시작 화면 
        static void DisplayGameIntro()
        {
            Console.Clear();

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

        // 1-1. 캐릭터 상태 보기 화면
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
            Console.WriteLine($"체력 : {player.MaxHealth}");
            Console.WriteLine($"마나 : {player.MaxMp}");
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
            Console.WriteLine($"마나 : {player.CurMp} / {player.MaxMp}");
            Console.WriteLine();
            //스킬출력
            if (isUseSkill == false)  //만약 스킬활성화가 아니면 isUseSkill => 
            {
                Console.WriteLine("스킬을 사용하시겠습니까?");   //물어보기
                Console.WriteLine("0. 취소");
                Console.WriteLine("1.공격한다");
                Console.WriteLine("2 스킬사용");

                int inp = CheckValidInput(0, 2);
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
                }
            }
            if (isUseSkill == true)                               //스킬이 활성화면
            {
                int i = 1;
                foreach (Skill skill in skills)                   //skills리스트에 있는 스킬들 출력
                {
                    Console.WriteLine($"{i} {skill.Name} - 사용마나{skill.UseMp}");
                    Console.WriteLine($"공격력의{skill.MultiAtk}배로 {skill.AtkNumber}명의 적을 공격합니다.");
                    Console.WriteLine("");
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("스킬을 골라주세요");
                skillSelect = CheckValidInput(1, skills.Count);    //어떤스킬 사용할지 입력받기
                if (player.CurMp < skills[skillSelect - 1].UseMp)  //마나가 부족하면
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;//경고 문구 노랑색 배경  
                    Console.WriteLine("마나가 부족합니다");
                    Console.ResetColor();//경고 문구 색 끝 
                    isUseSkill = false;                             //비활성화
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
                        Console.ForegroundColor = ConsoleColor.DarkYellow;//죽은놈 문구 노랑색 
                        Console.WriteLine("이미 죽은 몬스터입니다.");
                        Console.ResetColor();//노랑색 끝  
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;//캐릭터의 공격 초록색  
            Console.WriteLine();
            if (player.MyTurn == true) // 내 턴일때
            {
                int damage = 0;
                int sumskilldamage = 0;  //스킬데미지 종합
                int err = (int)Math.Ceiling(player.Atk / 10f); //int err = Math.Ceiling(player.Atk/10);
                if (isUseSkill == true)  //스킬 활성화면
                {
                    for (int i = 0; i < skills[skillSelect - 1].AtkNumber; i++)  //공격횟수만큼 공격
                    {
                        damage = skills[skillSelect - 1].MultiAtk * ran.Next((int)Math.Round(player.Atk - err), (int)Math.Round(player.Atk + err));
                        Console.WriteLine($"{player.Name}의 {skills[skillSelect - 1].Name}!");
                        sumskilldamage += damage;
                    }
                    Console.WriteLine($"{ranMonsters[inp - 1].Name}을(를) {skills[skillSelect - 1].AtkNumber}번 맞췄습니다. [데미지 : {sumskilldamage}]");
                    damage = sumskilldamage;
                    player.CurMp -= skills[skillSelect - 1].UseMp;
                    Console.WriteLine($"마나 {player.MaxMp} -> {player.CurMp} ");

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
                isUseSkill = false;
                Console.ResetColor();//캐릭터의 공격 초록색 글자 끝

                Thread.Sleep(1000);

                Console.ForegroundColor = ConsoleColor.DarkRed;//몬스터의 공격 빨강색 
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
                player.MyTurn = true;
                Console.ResetColor();//몬스터 공격 빨강색 끝

                if (monDeadCount == ranMonsters.Length)
                {
                    DisplayVictory();
                }

                Console.WriteLine("0. 다음"); // 0으로 넘어갈지 thread.sleep으로 시간차 두고 넘어갈지 정하기
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;//안내 문구 노랑색 
                Console.WriteLine("플레이어의 턴이 아닙니다.");
                Console.ResetColor();//노랑색 끝 
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



//----------------------------------------------입력 필터 함수----------------------------------------------------
        
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

                Console.ForegroundColor = ConsoleColor.DarkYellow;//안내 문구 노랑색 
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();//노랑색 끝 
            }
        }


//--------------------------------------------전투 결과(레벨업 정보)----------------------------------------------
       
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
                Console.WriteLine(DropItem().Name);    //드롭될 아이템을 생성(new)하고 그 이름을 출력

            }

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            monsters = new Monster[4] { CreateMonster(), CreateMonster(), CreateMonster(), CreateMonster() }; // 몬스터가 다 죽으면 새로운 몬스터를 생성하는 코드
            ranMonsters = new Monster[ran.Next(1, 4)];
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
            Console.WriteLine("You Lose");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level} {player.Name}");
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

        static Item DropItem()  // ※ 나중엔 인벤토리에 저장해야할 듯
        {
            int itemIndex = 0;
            itemIndex = ran.Next(1, 5);
            switch (itemIndex)
            {
                case 1:
                    return new Item("포션");
                    break;
                case 2:
                    return new Item("낡은검");
                    break;
                case 3:
                    return new Item("낡은활");
                    break;
                case 4:
                    return new Item("낡은스태프");
                    break;
                case 5:
                    return new Item("500G");
            }

            return new Item("돌맹이");

        }

//--------------------------------------------플레이어 직업과 몬스터 종류----------------------------------------------
        
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
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            
            // 이름 설정
            Console.Write("이름을 설정해주세요:");
            string userName = Console.ReadLine();


            JobType choice = ChooseJob();

            switch (choice)
            {
                case JobType.Worrior:
                    player = new Character(userName, "전사", 1, 8, 10, 10000, 150, 150, 0, 10, 50, 50, true);
                    break;
                case JobType.Archer:
                    player = new Character(userName, "궁수", 1, 10, 5, 10000, 120, 120, 0, 10, 50, 50, true);
                    break;
                case JobType.Mage:
                    player = new Character(userName, "마법사", 1, 5, 5, 10000, 100, 100, 0, 10, 120, 120, true);
                    break;
            }
            Console.WriteLine($"{player.Name}, {player.Job}를 생성합니다.");
            Thread.Sleep(1000);


        }

        // 몬스터 종류
        enum MonsterType
        {
            None = 0,
            미니언 = 1,
            대포미니언 = 2,
            공허충 = 3,
            바선생 = 4,
            귀멸의강낭콩 = 5
        }

        static MonsterType ChooseMonster()
        {
            MonsterType mon = MonsterType.None;

            int input = ran.Next(1, 5);
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
            }
            return mon;
        }
        static Monster CreateMonster()  //몬스터를 랜덤으로 생성
        {
            MonsterType mon = ChooseMonster();

            switch (mon)
            {
                case MonsterType.미니언:
                    return new Monster("미니언", 2, 15, 15, 5, false);
                    break;
                case MonsterType.대포미니언:
                    return new Monster("대포미니언", 5, 25, 25, 8, false);
                    break;
                case MonsterType.공허충:
                    return new Monster("공허충", 3, 10, 10, 9, false);
                    break;
                case MonsterType.바선생:
                    return new Monster("바선생", 7, 20, 20, 10, false);
                    break;
                case MonsterType.귀멸의강낭콩:
                    return new Monster("귀멸의강낭콩", 10, 25, 25, 10, false);
                    break;
                default:
                    return new Monster("미니언", 2, 15, 15, 5, false);
                    break;
            }
        }
    }

}