using System.Reflection.Emit;

namespace TextRPG_Team12
{
    public class Trol : Monster{

 

        public Trol()
        {

            Name = "트롤";
            Health = 20;
            AttackPower = 2;
            LootMoney = 5 * (int)Math.Round(rand.Next(200, 300) / 5.0); // 5씩 나눠 떨어지도록 설정 200, 205, 210, 215 ... 
            HuntExp = 5 * (int)Math.Round(rand.Next(50, 101) / 5.0); 

        }

        public Trol(int stagelevel)
        {


            Name = "트롤";
            Health = 20;
            AttackPower = 2;
            LootMoney = 5 * (int)Math.Round(rand.Next(200, 300) / 5.0); // 5 단위로 끊어서 표현
            HuntExp =  5 * (int)Math.Round(rand.Next(50, 101) / 5.0); // 5씩 나눠 떨어지도록 설정 50, 55, 60, 65 ... 

            StageEnemySet(stagelevel);


        }


    }

   
}
