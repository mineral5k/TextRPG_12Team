using System.Data.SqlTypes;
using System.Reflection.Emit;

namespace TextRPG_Team12
{
    public class Dragon : Monster 
    {

        public  Dragon()
        {

           
            Name = "드래곤";
            Health = 30;
            AttackPower = 3;
            LootMoney = 5 * (int)Math.Round(rand.Next(300, 400) / 5.0); // 5 단위로 끊어서 표현 -> 300, 305, 310, 315, .... 
            HuntExp = 5 * (int)Math.Round(rand.Next(100, 151) / 5.0); // 5 단위로 끊어서 표현

        }

        public Dragon(int stagelevel)
        {


            Name = "드래곤";
            Health = 30; 
            AttackPower = 3;
            LootMoney = 5 * (int)Math.Round(rand.Next(300, 400) / 5.0); // 5 단위로 끊어서 표현 -> 300, 305, 310, 315, .... 
            HuntExp = 5 * (int)Math.Round(rand.Next(100, 151) / 5.0); // 5 단위로 끊어서 표현

            StageEnemySet(stagelevel);


        }
   

    }

   
}
