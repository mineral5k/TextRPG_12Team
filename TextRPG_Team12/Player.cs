

using System.ComponentModel;

namespace TextRPG_Team12
{
    public class Player : Character
    {

        public static readonly int[] LevelUpExp = { 0, 10, 35, 65, 100 };

        public List<Equipment> Inventory = new List<Equipment>();
        private static List<Equipment> EquipList = new List<Equipment>();
        public List<Equipment> ShopList = new List<Equipment>();

        public Job job ;

  
        public int Gold { get; set; }

        public int AmorDefense { get; set; }

        public int WeaponStat { get; set; }

        public int AmorStat {get; set; }

    
        public int Exp { get; set;}

        public int Mana { get; set;}

        public int MaxMana { get; set; }
   



        public Player(string name, Job inputJob)
        {
            Name = name;
            job = inputJob;  
            Level = 1;
            Gold = 1500;
            Health = 100 +job.JobHealth;
            MaxMana = 50 + job.JobMana;
            Mana = 50 + job.JobMana;
            AttackPower = 10 +job.JobAttackPower;
            AmorDefense = 5 + job.JobAmorDeffense;

        }

        public void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"LV : {Level}");
            Console.WriteLine($"직업 : {job.JobName}");
            Console.WriteLine($"공격력 : {AttackPower + WeaponStat} ( + {WeaponStat})");
            Console.WriteLine($"방어력 : {AmorDefense + AmorStat} (+ {AmorStat})");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"GOLD: {Gold}");
            Console.WriteLine();
            Console.WriteLine($"0. 나가기");


        }

        public int ShowInventory(bool showIdx)
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Console.WriteLine();
            
            for (int i = 0; i < Inventory.Count;  i++)
            {
                Equipment targetInventory = Inventory[i];

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = IsEquipped(targetInventory) ? "[E]" : "";
                Console.WriteLine($"- {displayIdx}{displayEquipped} {targetInventory.EquipmentStatText()}");

          
            }

            Console.WriteLine();
            Console.WriteLine(!showIdx ? "1. 장착관리" : "");
            Console.WriteLine($"0. 나가기");

            return Inventory.Count;
        }




        public void GetExp(int EnemyExp)
        {

            Console.WriteLine($"{EnemyExp}의 경험치를 획득했습니다.");
            Exp += EnemyExp;
            if (LevelUpExp[Level] < Exp)
            {
                Console.WriteLine($"축하합니다. 레벨업 하였습니다.");

                Level += 1;
                Exp -= LevelUpExp[Level];

                AttackPower += 1;
                AmorDefense += 1;
                
            }


        }



        public void EquipItem(int TargetNum)
        {

           if (TargetNum < 0)
                return;
           

            Equipment EquipItem = Inventory[TargetNum];

            if (IsEquipped(EquipItem))
            {
                EquipList.Remove(EquipItem);
                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat -= EquipItem.Attack;
              
                }
                else
                    AmorDefense -= EquipItem.Defense;

            }
            else
            {
                EquipList.Add(EquipItem);
                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat += EquipItem.Attack;
                }
                else
                    AmorDefense += EquipItem.Defense;
            }

        }


        public bool IsEquipped(Equipment item)
        {
            return EquipList.Contains(item);
        }

        public int ShowShop(bool showIdx)
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Gold}");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");


            for (int i = 0; i < ShopList.Count; i++)
            {
                Equipment targetInventory = ShopList[i];

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = IsEquipped(targetInventory) ? "[E]" : "";
                Console.WriteLine($"- {displayIdx}{displayEquipped} {targetInventory.EquipmentStatText()} { (targetInventory.IsPurchased ? "구매완료" : $"{targetInventory.Price} G" )}");


            }

            Console.WriteLine();
            Console.WriteLine(!showIdx ? "1. 아이템구매\n2. 아이템판매" : "");
            Console.WriteLine($"0. 나가기");

            return ShopList.Count;


        }

        public void BuyShop(int TargetNum)
        {

            if (TargetNum < 0)
                return;



            Equipment targetItem = ShopList[TargetNum];


            if (targetItem.IsPurchased != true && Gold > targetItem.Price)
            {

                ShopList[TargetNum].IsPurchased = true;
                targetItem.IsPurchased = true;
                
                Inventory.Add(targetItem);

                Gold -= targetItem.Price;



                Console.WriteLine("구매를 완료했습니다.");
              

            }
            else if (targetItem.IsPurchased != true && Gold < targetItem.Price)
            {


                Console.WriteLine("Gold가 부족합니다.");
                


            }
            else if (targetItem.IsPurchased)
            {

                Console.WriteLine("이미 구매한 아이템입니다.");
           

            }

        
            Thread.Sleep(1000);
           


        }


        public void SellShop(int TargetNum)
        {


            if (TargetNum < 0)
                return;

            Equipment targetItem = ShopList[TargetNum];

            if (targetItem.IsPurchased == true)
            {
            
                if (IsEquipped(targetItem))
                {
                    EquipList.Remove(targetItem);
                    if (targetItem.Type == EquipmentType.Weapon)
                    {
                        WeaponStat -= targetItem.Attack;
                    }
                    else
                        AmorDefense -= targetItem.Defense;

                }

                Gold += targetItem.Price;
                
                Inventory.Remove(targetItem);
                ShopList[TargetNum].IsPurchased = false;
                

                Console.WriteLine("아이템을 판매했습니다.");
              
            }

            else 
                Console.WriteLine("판매할 수 없는 아이템입니다.");

            Thread.Sleep(1000);

   

        }



    }
}
