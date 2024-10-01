namespace TextRPG_Team12
{
    public class Goblin : Monster
    {

        public List<ItemType> RewardItemDB;


        void RewardItemData()
        {

            RewardItemDB = new List<ItemType>
            {
                //new Equipment("속임수 단검", "고블린이 즐겨 쓰는 독이 발린 단검. 작지만 치명적이다.", 5, 0, 1000, EquipmentType.Weapon),
                //new Equipment("고블린 가죽 조끼", "장인이 만든 가벼운 가죽 조끼. 움직임이 자유롭고 은밀한 행동에 유리하다", 5, 0, 1000, EquipmentType.Armor),
         

                new Miscellaneous("고블린의 주머니", "고블린 족장이 허리에 차고 다니는 작은 가죽 주머니. ", 1, 150)



            };


        }
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
