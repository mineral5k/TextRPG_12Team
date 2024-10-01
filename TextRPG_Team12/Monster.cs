﻿using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : Character
    {
        public Random rand = new Random();

        public List<ItemType> CommonItemlistDB;



        public int LootMoney;
        public int HuntExp;



        void CommontemData()
        {

            CommonItemlistDB = new List<ItemType>
            {
                //new Equipment("", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
                //new potion();
                //new

                new Miscellaneous("마른 나뭇가지", "평범해 보이는 나뭇가지지만 마법 지팡이의 재료로 사용된다.", 1, 25),
                new Miscellaneous("빛나는 돌", "동굴에서 발견되는 희귀한 돌. 어둠 속에서 은은한 빛을 내 장신구 제작에 사용된다", 1, 200),
               
                
            };


        }






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
