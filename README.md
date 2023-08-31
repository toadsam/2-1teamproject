# 팀과제 콘솔 게임

# 😁스파르타 던전 배틀 (Text 게임)

## 프로젝트 소개

- 던전에 도착한 캐릭터가 전투를 하는 게임을 텍스트로 구현한 게임입니다.

## 개발기간

- 2023/08/28 ~ 2023/09/01

## ❤맴버 구성❤

- 팀장 : 김윤경
    - 🔴 **필수 요구사항** 3 - 3. 전투 결과
    - 🟢 **선택 요구사항 :** 4. 치명타 기능[Battle]
      5. 회피 기능[Battle]
      10. 아이템 적용[Common]
      14. 전투 중 포션 사용[Common - 나만의 기능]
      14. 레벨 맞춤 스킬[Common - 나만의 기능]
- 팀원 : 정재훈
    - 🔴 **필수 요구사항** 1. 게임 시작 화면    2. 상태 보기   3-1. 결과 표시
    - 🟢 **선택 요구사항 :** 3. 스킬 기능[Battle]                                                                                                                           11. 회복 아이템[Common]       14. ReadMe 작성                                                                                             13. 게임 저장하기[Common]  
    14. 직업별 스킬[Common - 나만의 기능]
- 팀원 : 이장원
    - 🔴 **필수 요구사항**  3. 전투 시작
    - 🟢 **선택 요구사항 :** 예비군 훈련
       ReadMe 작성
- 팀원 : 이민열
    - 🔴 **필수 요구사항** 3 - 1. 공격
    - 🟢 **선택 요구사항 :** 2. 직업 선택 기능[Character Custom]
       6. 레벨업 기능[Dungeon Result]
       7. 보상 추가[Dungeon Result]
       12. 스테이지 추가[Common]
       14. 몬스터 스킬 추가[Common - 나만의 기능]
       14. 보스 몬스터 추가[Common - 나만의 기능]
       14. 전체 공격, 랜덤 공격(스킬 추가)[Common - 나만의 기능]
- 팀장 : 어하림
    - 🔴 **필수 요구사항**  3 - 2. Enemy Phase
    - 🟢 **선택 요구사항 :** 8. 콘솔 꾸미기[Common] 글자 색
      9. 몬스터 종류 추가해보기[Common] 2마리
      14. 방어력 기능 추가[Common - 나만의 기능]
      14. 플레이어가 몬스터 공격 피하기[Common - 나만의 기능]

## **⚙️ 개발 환경**

- Visual Studio - C#

## 🌐주요 기능

- 🎮게임 시작 화면
    - 게임 시작시 간단한 소개 말과 마을에서 할 수 있는 행동을 알려줍니다.
    - 원하는 행동의 숫자를 타이핑하면 실행합니다.
    
    ```csharp
    이제 전투를 시작할 수 있습니다.
    
    1. 상태보기
    2. 전투시작 (현재 진행 : 2층)
    3. 인벤토리
    4. 저장하기
    
    원하시는 행동을 입력해주세요.
    ```
    

- 💾상태 보기
    - 캐릭터의 정보를 표시합니다.
    - 7개의 속성을 가지고 있습니다.
    레벨 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
    - 이후 장착한 아이템에 따라 수치가 변경 될 수 있습니다.
    
    ```csharp
    상태보기
    
    캐릭터의 정보를 표시합니다.
    
    Lv.2
    재훈(마법사)
    공격력 :6.5
    방어력 : 10
    체력 : 100 | 73
    마나 : 120  | 45
    Gold : 10000 G
    
    0. 나가기
    ```
    

- ⚔️전투 시작
    - 전투를 시작하면 1~5마리의 몬스터가 랜덤하게 등장합니다.
    - 몬스터는 6종류 있습니다.
        - 중복해서 나타날 수 있습니다.
    
    ```csharp
    Battle!!
    
    [몬스터 종류]
    Lv.5 대포미니언 HP 25
    
    Lv.5 대포미니언 HP 25
    
    [내 정보]
    Lv.2 재훈 (마법사)
    HP 73 / 100
    마나 : 45 / 120
    
    0. 나가기
    1. 공격
    
    원하시는 행동을 입력해주세요
    ```
    

- 🤡캐릭터 커스텀
    - 게임이 시작하면 이름을 코드로 정해두고 시작합니다.
    - 직업을 선택 할 수 있습니다. 캐릭터마다 능력치가 다릅니다.
    
    ```csharp
    ♣ 스파르타 던전에 오신 여러분 환영합니다. ♣
    
    저번 캐릭터를 이어하시겠습니까?
    1. 저번 캐릭터 이어하기
    2. 새로하기
    
    2
    이름을 설정해주세요:재훈재훈재훈재훈재훈
    
    직업을 선택하세요
    1. 전사
    2. 궁수
    3. 마법사
    ```
    

- 🤺배틀
    - 스킬 사용
        - 전투 시작에서 1.공격을 누르면 스킬을 사용할 수 있습니다.
        - Battle 에서 내정보에 MP 를 추가하고  스킬 항목을 추가했습니다.
            
            ```csharp
            [몬스터 종류]
            1 Lv.2 미니언 HP 15
            
            2 Lv.2 미니언 HP 15
            
            [내 정보]
            Lv.1 재훈재훈재훈재훈재훈 (마법사)
            HP 100 / 100
            마나 : 120 / 120
            
            스킬을 사용하시겠습니까?
            0. 취소
            1. 공격한다
            2. 스킬사용
            3. 포션 마시기
            2
            1 알파 스트라이크 - 사용마나10
            공격력의2배로 1명의 적을 공격합니다.
            
            2 더블 스트라이크 - 사용마나15
            공격력의2배로 2명의 적을 공격합니다.
            
            3 고무고무 피스톨 - 사용마나45
            공격력의99배로 9명의 적을 공격합니다.
            
            스킬을 골라주세요
            ```
            
    - 치명타 , 회피 기능
        - ran.Next()를 이용해서 일정 확률로 bool값에 true값을 넣어 기능을 구현하였습니다.
        
        ```csharp
                            bool isAtkUp = ran.Next(0, 100) < 15; // 15프로 확률
                            bool isDodgeAtk = ran.Next(0, 100) < 10; // 10프로 확률
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
        ```
        

- 🦧던전추가 기능
    - 레벨업 기능
        - 몬스터마다 얻는 경험치를 다르게 해서 foreach문을 통해 일정 경험치를 넘으면 레벨을 올리도록 구현하였습니다.
        
        ```csharp
        foreach (Monster mon in ranMonsters)
                    {
                        getExp += mon.Level;
                    }
        ublic void LevelUp()
                {
                    Atk += 0.5f;             // 레벨업 시 기본 공격력 + 0.5, 방어력 + 1
                    Def += 1;
                    Exp = Exp - TotalExp;
                    Level += 1;
                    TotalExp += (20 + (Level - 1) * 5);         // 1는 10 필요, 2~3은 35필요, 3~4는 65, 4~5는 100, 만렙은 5이며 exp증가 X
                                                                //레벨업은 player.Level++ / totalExp를 그에 맞게 올림 / totalExp는 += 20 + (level-1)*5(레벨이 2 이상이면)
                }
        ```
        
        ```csharp
        Battle!! - Result
        Victory
        
        던전에서 몬스터 3마리를 잡았습니다.
        
        [캐릭터 정보]
        Lv.1 재훈재훈재훈재훈재훈 -> Lv.2 재훈재훈재훈재훈재훈
        ```
        
    - 보상 추가
        - 몬스터의 수 까지 itemCount을 랜덤으로 받아  itemCount 만큼 switch문을 이용하여 아이템이 랜덤으로 나오도록 구현하였습니다.
        
        ```csharp
        itemIndex = ran.Next(1, 4);
                    switch (itemIndex)
                    { 
                        case 1:
                            return new Item("낡은 검", "공격력", 3f, "쉽게 볼 수 있는 낡은 검 입니다.", false, "dropitem");             
                        case 2:
                            return new Item("낡은 활", "공격력", 4f, "신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.", false, "dropitem");
                        case 3:
                            return new Item("낡은 스태프", "방어력", 2f, "적의 공격으로부터 보호를 제공하는 동시에 주문력을 발휘할 수 있는 스태프입니다.", false, "dropitem");                    
                    return new Item("돌맹이", "공격력", 4, "원거리에서는 투척하여 적에게 공격을 가하는 방식으로 사용되는 돌멩이입니다.", false, "dropitem");
                }
        
        int itemCount = ran.Next(1, ranMonsters.Length);
                    for (int i = 0; i < itemCount; i++)
                    {//itemCount 만큼 아이템 랜덤 생성 }
        ```
        
        ```csharp
        [획득 아이템]
        마나포션 획득
        낡은 활
        체력포션 획득
        낡은 활
        ```
        

- 🤪콘솔 꾸미기
    - ConsoleColor를 이용해서 다양한 색을 구현했습니다.
    
    ```csharp
    Console.ForegroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Yellow;
    ```
    
    ```csharp
    1. 장착 관리
    2. 아이템 정렬
    0. 나가기
    
    Battle!!
    
    [몬스터 종류]
    ```
    

- 🐯몬스터 종류
    - switch문을 이용해 능력이 각각 다른 6마리의 몬스터를 랜덤으로 생성 할 수 있습니다.
    
    ```csharp
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
    ```
    

- 🧐아이템 기능
    - DropeItemToInventory메서드를 이용해서 던전에서 얻은 아이템을 인벤토리에 추가할 수 있습니다.
    
    ```csharp
    static void DropeItemToInventory(Item item)
            {
                invenList.Add(item);
            }
    ```
    
    - invenList.OrderByDescending(x => x.PlayerEquipped).ToList()를 이용해 이룸, 장착순, 공격력, 방어력 별로 정렬할 수 있습니다.
    
    ```csharp
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
    ```
    
    ```csharp
    인벤토리 - 아이템 정렬
    보유 아이템들의 순서를 정렬해 볼 수 있습니다.
    
    ---------------------------------------[아이템 목록]----------------------------------------
    
    1.[E] 무쇠갑옷 |방어력(+3)|가격 0   G|무쇠로 만들어져 튼튼한 갑옷입니다.
    2.[X] 불타는도끼|공격력(+1)|가격 0   G|불꽃으로 베어내며 화염 공격을 가하는 도끼입니다.
    3.[X] 낡은 검 |공격력(+3)|가격 0   G|쉽게 볼 수 있는 낡은 검 입니다.
    4.[X] 낡은 활 |공격력(+4)|가격 0   G|신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.
    5.[X] 낡은 활 |공격력(+4)|가격 0   G|신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.
    
    --------------------------------------------------------------------------------------------
    
    1. 이름
    2. 장착순
    3. 공격력
    4. 방어력
    0. 나가기
    
    원하시는 행동을 입력해주세요.
    ```
    

- 💖회복 아이템
    - 인벤토리 창을 통해서 포션에 들어갈 수 있습니다.
    
    ```csharp
    회복
    체력포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : 3  현재체력: 7
    마나포션을 사용하면 마나을 30 회복 할 수 있습니다. (남은 포션 : 5 현재마나: 50
    
    2.체력포션 사용하기
    1.마나포션 사용하기
    0.나가기
    ```
    
    - 보상 아이템과 마찬가지로 ran.Next()를 이용하여 일정 확률에 따라 포션을 얻을 수 있습니다.
    - HpPotionUse , MpPotionUse 함수를 통해 체력과 마나를 포션갯수와 체력과 마나의 양에 따라 조건이 맞으면 회복할 수 있습니다.
    
    ```csharp
    public void HpPotionUse(Character character)
            {
                if (hpPotionCount == 0)
                {
                    Console.WriteLine($"남은 체력포션이 없습니다. ");
                }
                else
                {
                    if (character.CurHealth + Recovery > character.MaxHealth)
                    {
                        if (character.CurHealth == character.MaxHealth)
                        {
                            Console.WriteLine($"이미 최대 체력입니다. ");
                        }
                        else
                        {
                            character.CurHealth = character.MaxHealth;
                            hpPotionCount--;
                            Console.WriteLine($"체력이 {Recovery}만큼 회복되었습니다. 현재체력 : {character.CurHealth} ");
                            Console.WriteLine($"남은 체력물약: {hpPotionCount} ");
                        }
    ```
    

- ↗️스테이지 추가
    - 던전을 클리어할 때마다 한단계 더 높은 던전으로 입장합니다.
    - 더 높은 던전은 층으로 표시합니다.
    - switch문과 for문을 이용해 던전 레벨에 따라 높은 던접에서는 더 많은 몬스더가 나올 확률과 강한 몬스터가 등장할 수 있습니다.
    
    ```csharp
    1. 상태보기
    2. 전투시작 (현재 진행 : 3층) -> 현재 3층인 것을 나타냅니다.
    -------------------------------------------------------------------------------------
    switch (dungeonLevel)// 던전 레벨에 따라 몬스터 마리수를 무작위로 생성
                    {
                        case 1:
                            ranMonsters = new Monster[ran.Next(1, 4)];
                            break; ..............
    
    for (int i = 0; i < ranMonsters.Length; i++)
                {
                    ranMonsters[i] = monsters[i];
                }
    ```
    

- 🚀게임 저장하기
    - 데이더를 저장하거나, 데이터를 통신으로 보낼때 사용하는 json을 이용하여 저장기능을 구현하였습니다.
    - Save클래스를 만들어 저장하고 싶은 기능을 SaveInformation를 이용하여 담아 다른 파일로 옯긴후 다시 실행시 가져오도록 구현하였습니다.
        - class Save
            
            ```csharp
            public Character character;
                    public Potion potion;
                    public List<Item> saveItems;
                    public int MpCount;
                    public int HpCount;
                    public int saveDungeonLevel;
                    public void SaveInformation(Character _character, Potion _potion, List<Item> _items, int _dungeonLevel)
                    {//저장하고 싶은 값들을 인자값(파라미터 값으로 받아) save클래스의 멤버변수에 저장하는 함수 
                        character = _character;
                        potion = _potion;
                        MpCount = Potion.mpPotionCount;
                        HpCount = Potion.hpPotionCount;
                        saveItems = _items;
                        saveDungeonLevel = _dungeonLevel;
                    }
            ```
            
            ```csharp
            save.SaveInformation(player, potion,invenList,dungeonLevel);   //저장할 파일 담는 함수 위에 클래스의 함수
            
            var preuser = JObject.FromObject(save); //JObject은 Json객체를 의미 -> save객체를 JObject로 변환 후 preuser에 담기
            
            File.WriteAllText(@"C:\Users\82106\Documents\GitHub\2-1teamproject\SpartaTextRPG2.json", preuser.ToString());
            //지정된 파일 위치에다가 preuser를 문자열로 바꿔 적기 //지정된 파일위치에 문자열로 정보가 저장되어있다. 
            ```
            
            ```csharp
            var curuser = File.ReadAllText(@"C:\Users\82106\Documents\GitHub\2-1teamproject\SpartaTextRPG2.json");
            //위치에 있는 파일(저장했던 자료)을 읽어서 curuser에 저장
                                Save save2 = JsonConvert.DeserializeObject<Save>(curuser);
            //새로운 save2를 생성해서 curuser를 문자열로 저장했던걸 다시 json으로 바꾸주기
            
                                save = save2;//save2(정보가 담겨있는 객체)를 save로 옯기기
                                player = save.character;    //Program 클래스에 선언했던 객체와 변수에 저장했던 값 받기
                                potion = save.potion;
                                invenList = save.saveItems;
                                Potion.mpPotionCount = save.MpCount;
                                Potion.hpPotionCount = save.HpCount;
                                dungeonLevel = save.saveDungeonLevel;
            ```
