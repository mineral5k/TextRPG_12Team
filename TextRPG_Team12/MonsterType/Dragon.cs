using System.Data.SqlTypes;
using System.Reflection.Emit;

namespace TextRPG_Team12
{
    public class Dragon : Monster
    {


        void RewardItemData()
        {

            RewardItemDB = new List<ItemType>
            {
                //new Equipment("용의 비늘 갑옷", "용의 비늘로 만들어져 물리 공격과 마법 공격 모두에 강한 저항력을 지닌다", 5, 0, 1000, EquipmentType.Armor),
                //new Equipment("용기사의 투구", "착용자에게 강한 용기를 불어넣어 공포 저항력을 높여준다.", 5, 0, 1000, EquipmentType.Armor),
         
                new Miscellaneous("용의 이빨", "날카로운 용의 이빨. 일부지역에서는 화폐로도 통용된다", 75)

                

            };


        }


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
