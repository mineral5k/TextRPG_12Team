using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : Character
    {
        public Random rand = new Random();

        public int LootMoney;
        public int HuntExp;

        public void StageEnemySet(int Stagelevel)
        {

            Level = rand.Next(Stagelevel, Stagelevel+4);

            // 스테이지 + 레벨 별 일정량 증가
            Health += (5 * Level); 
            AttackPower += (1 * Level);
            LootMoney += (10 * Level);
            HuntExp += (15 * Level);


        }




    }


}
