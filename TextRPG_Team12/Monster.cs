using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : Character
    {
        public Random rand = new Random();

        public List<ItemType> CommonItemlistDB;
        public List<ItemType> RewardItemDB;



        public int LootMoney;
        public int HuntExp;
        public int PoisonTurn = 0;
        public int PoisonDamage = 0;
        public int stun = 0;


        public void CommontemData()
        {

            CommonItemlistDB = new List<ItemType>
            {
                new Equipment("땀에 젖은 훈련복 ", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
                new Potion("체력 포션", "체력을 50 회복한다", 1, 50),
                new Potion("마나 포션", "마나를 30 회복한다", 2, 30),
                new Miscellaneous("마른 나뭇가지", "평범해 보이는 나뭇가지지만 마법 지팡이의 재료로 사용된다.", 25),
                new Miscellaneous("빛나는 돌", "동굴에서 발견되는 희귀한 돌. 어둠 속에서 은은한 빛을 내 장신구 제작에 사용된다", 200),
               
                
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
            MaxHealth = Health;


        }



        public void WinningPrize(Player player)
        {
           
            int Selectnum = rand.Next(0, 2);
     

            for (int i = 0; i < Selectnum; i++)
            {

                int IteDBmNum = rand.Next(0, RewardItemDB.Count);
                ItemType TargetItem = RewardItemDB[IteDBmNum];

                if (TargetItem is Equipment)
                {

                    Console.WriteLine($"{TargetItem.Name}");

                    if (!player.isItemHave(TargetItem))
                    {

                        TargetItem.HasNum = 1;
                        player.Inventory.Add(TargetItem);

                    }

                }

                else 
                {
                    int Itemnum = rand.Next(1, 3);


                    if (player.isItemHave(TargetItem))
                    {

                        int inventoryItemnum = player.Inventory.IndexOf(TargetItem);

                        if ((player.Inventory[inventoryItemnum].HasNum += Itemnum) <= 99)
                            player.Inventory[inventoryItemnum].HasNum += Itemnum;
                        else
                            player.Inventory[inventoryItemnum].HasNum = 99;

                    }
                    else
                    {
                        TargetItem.HasNum = Itemnum;
                        player.Inventory.Add(TargetItem);


                    }

                    Console.WriteLine($"{TargetItem.Name} X {Itemnum}");
                }
               

                

            }
        
        
        }


    }



}
