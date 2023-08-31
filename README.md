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

- 🎮게임 시작 화면  -  [자세히 보기](https://github.com/toadsam/TextGame/wiki/%EC%BA%90%EB%A6%AD%ED%84%B0)
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
    

- 💾상태 보기  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%83%81%ED%83%9C-%EB%B3%B4%EA%B8%B0)
   
    

- ⚔️전투 시작  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%A0%84%ED%88%AC-%EC%8B%9C%EC%9E%91)
   
    

- 🤡캐릭터 커스텀  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%BA%90%EB%A6%AD%ED%84%B0-%EC%BB%A4%EC%8A%A4%ED%85%80)
   
    

- 🤺배틀  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EB%B0%B0%EB%93%A4)
    
        

- 🦧던전추가 기능  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EB%8D%98%EC%A0%84%EC%B6%94%EA%B0%80-%EA%B8%B0%EB%8A%A5)
    
        

- 🤪콘솔 꾸미기  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%BD%98%EC%86%94-%EA%BE%B8%EB%AF%B8%EA%B8%B0)
    

- 🐯몬스터 종류  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EB%AA%AC%EC%8A%A4%ED%84%B0-%EC%A2%85%EB%A5%98)
    

- 🧐아이템 기능  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%95%84%EC%9D%B4%ED%85%9C-%EA%B8%B0%EB%8A%A5)
   
    

- 💖회복 아이템  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%ED%9A%8C%EB%B3%B5-%EC%95%84%EC%9D%B4%ED%85%9C)
   

- 🚀게임 저장하기  -  [자세히 보기](https://github.com/toadsam/2-1teamproject/wiki/%EC%83%81%ED%83%9C-%EB%B3%B4%EA%B8%B0)
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
