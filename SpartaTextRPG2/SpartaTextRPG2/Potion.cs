namespace SpartaTextRPG2
{
    public class Potion
    {

        public static int hpPotionCount = 3;
        public static int mpPotionCount = 3;

        public string Name { get; set; }
        public int Recovery { get; set; }

        public Potion() 
        {
           
            Recovery = 30;
        }

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
                }
                else if (character.CurHealth + Recovery < character.MaxHealth)
                {
                    character.CurHealth +=Recovery;
                    hpPotionCount--;
                    //체력회복 리스트에서 삭제하기
                    Console.WriteLine($"체력이 {Recovery}만큼 회복되었습니다. 현재체력 : {character.CurHealth} ");
                    Console.WriteLine($"남은 체력물약: {hpPotionCount} ");
                }
                
            }
        }
        public void MpPotionUse(Character character)
        {
            if (mpPotionCount == 0)
            {
                Console.WriteLine($"남은 마나포션이 없습니다. ");
            }
            else
            {
                if (character.CurMp + Recovery >= character.MaxMp)
                {
                    if (character.CurMp == character.MaxMp)
                    {
                        Console.WriteLine($"이미 최대 마나입니다. ");
                    }
                    else
                    {
                        character.CurMp = character.MaxMp;
                        mpPotionCount--;
                        Console.WriteLine($"마나가 {Recovery}만큼 회복되었습니다. 현재마나 : {character.CurMp} ");
                        Console.WriteLine($"남은 마나물약: {mpPotionCount} ");
                    }
                }
                else if (character.CurMp + Recovery < character.MaxMp)
                {
                    character.CurMp +=Recovery;
                    mpPotionCount--;
                    //체력회복 리스트에서 삭제하기
                    Console.WriteLine($"마나가 {Recovery}만큼 회복되었습니다. 현재마나 : {character.CurMp} ");
                    Console.WriteLine($"남은 마나물약: {mpPotionCount} ");
                }
                
            }
        }


    }
}
