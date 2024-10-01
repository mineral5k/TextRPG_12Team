using System.Reflection.Emit;

namespace TextRPG_Team12
{
    public class Trol : Monster{

        public void RewardItemData()
        {

            RewardItemDB = new List<ItemType>
            {
                //new Equipment("트롤 가죽 갑옷", "트롤의 두꺼운 가죽으로 만든 갑옷. 거칠지만 놀라운 방어력을 자랑한다.", 5, 0, 1000, EquipmentType.Armor),
                //new Equipment("트롤 분쇄기", "거대한 나무 기둥에 쇠사슬로 바위를 매달아 만든 트롤의 무기.", 5, 0, 1000, EquipmentType.Weapon),
         
                new Miscellaneous("트롤의 재생 돌", "트롤의 심장 근처에서 발견되는 작고 거친 돌. 트롤의 빠른 재생 능력의 원천으로 여겨진다.", 100)


            };

        }


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

            CommontemData();
            RewardItemData();


            foreach (ItemType commomitem in CommonItemlistDB)
            {

                RewardItemDB.Add(commomitem);

            }


            // 아이템 정렬 하기 


        }


    }

   
}
