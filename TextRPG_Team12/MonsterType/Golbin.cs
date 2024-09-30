namespace TextRPG_Team12
{
    public class Goblin : Monster
    {

       
        public Goblin()
        {

            Name = "고블린";
            Health = 10;
            AttackPower = 1;
            LootMoney = 5 * (int)Math.Round(rand.Next(100, 200) / 5.0); // 5씩 나눠 떨어지도록 설정 200, 205, 210, 215 ... 
            HuntExp = (5 * (int)Math.Round(rand.Next(0, 51) / 5.0)); // 5 단위로 끊어서 표현

        }

        public Goblin(int stagelevel)
        {


            Name = "고블린";
            Health = 10;
            AttackPower = 1;
            LootMoney = 5 * (int)Math.Round(rand.Next(100, 200) / 5.0); // 5 단위로 끊어서 표현
            HuntExp = (5 * (int)Math.Round(rand.Next(0, 51) / 5.0)); // 5 단위로 끊어서 표현

            StageEnemySet(stagelevel);


        }


    }

}
