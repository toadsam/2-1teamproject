# Sparta Dungeon Battle

C# 콘솔 환경에서 구현한 팀 프로젝트형 텍스트 RPG입니다. 캐릭터, 아이템, 몬스터, 스킬, 저장 기능을 분리해 던전 전투 흐름을 구성한 프로젝트입니다.

## 프로젝트 개요

`Sparta Dungeon Battle`은 콘솔 입력만으로 캐릭터를 성장시키고 몬스터와 전투하는 RPG입니다. 필수 요구사항을 충족하는 데서 끝나지 않고, 팀원이 선택한 확장 기능을 추가해 게임 루프를 더 풍부하게 만드는 데 초점을 맞췄습니다.

## 주요 기능

- 캐릭터 정보와 전투 능력치 관리
- 아이템과 포션 시스템
- 몬스터 데이터와 전투 처리
- 스킬 사용 흐름
- 게임 진행 데이터 저장 기능
- JSON 기반 데이터 파일 활용

## 기술 스택

- C#
- .NET 6
- Visual Studio 솔루션 구조
- 콘솔 애플리케이션

## 폴더 구조

```text
.
├── README.md
├── SpartaTextRPG2.json
└── SpartaTextRPG2/
    ├── SpartaTextRPG2.sln
    └── SpartaTextRPG2/
        ├── Character.cs
        ├── Item.cs
        ├── Monster.cs
        ├── Potion.cs
        ├── Program.cs
        ├── Save.cs
        └── Skill.cs
```

## 실행 방법

### Visual Studio에서 실행

1. Visual Studio 2022를 실행합니다.
2. `SpartaTextRPG2/SpartaTextRPG2.sln` 파일을 엽니다.
3. 시작 프로젝트가 `SpartaTextRPG2`인지 확인합니다.
4. `F5` 또는 `Ctrl + F5`로 실행합니다.

### CLI에서 실행

```bash
cd SpartaTextRPG2/SpartaTextRPG2
dotnet run
```

## 학습 포인트

- 콘솔 입력 흐름을 게임 루프로 구성하는 방법
- 클래스를 기준으로 RPG 도메인을 분리하는 방법
- 캐릭터, 아이템, 몬스터, 스킬 간의 의존성을 관리하는 방법
- 저장 기능을 별도 클래스로 분리하는 방법

## 개선 아이디어

- 전투 로그와 선택지 UX 개선
- 몬스터/아이템 데이터를 외부 JSON으로 완전히 분리
- 예외 입력 처리 강화
- 저장 슬롯 또는 자동 저장 추가
