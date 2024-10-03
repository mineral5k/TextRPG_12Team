

using System.ComponentModel;
using System.Numerics;
using static TextRPG_Team12.Quest;

namespace TextRPG_Team12
{
    public class Player : Character
    {

        public static readonly int[] LevelUpExp = { 0, 100, 350, 650, 1000};

        public List<ItemType> Inventory = new List<ItemType>();
        public List<Equipment> EquipList = new List<Equipment>();

        public List<Quest> Quests { get; private set; }

        public List<Equipment> ShopList = new List<Equipment>();

        public Stage stage =new Stage();


        public Job job ;

  
        public int Gold { get; set; }

        public int AmorDefense { get; set; }

        public int WeaponStat { get; set; }

        public int AmorStat {get; set; }

    
        public int Exp { get; set;}

        public int Mana { get; set;}

        public int MaxMana { get; set; }

        public bool Counter {  get; set; }

        public bool EvadeBuff { get; set; }
   
        



        public Player(string name, Job inputJob)
        {
            Name = name;
            job = inputJob;  
            Level = 1;
            Gold = 1500;
            Health = 100 ;
            MaxHealth =Health;
            MaxMana = 50 ;
            Mana = 50 ;
            AttackPower = 10 ;
            AmorDefense = 5;
            Quests = new List<Quest>();
            Counter = false;
            EvadeBuff = false;
            Evasion = 10;
            Critical = 10;

        }

        public override void TakeDamage(int damage)
        {
            int deDamage = damage - AmorDefense / 3; 
            if (deDamage < 0) deDamage = 0;
            
            UImanager.BlinkText($"{Name}이(가) {deDamage}의 데미지를 받았습니다.", 2, 200, ConsoleColor.DarkGray, ConsoleColor.White);


            Health -= deDamage;
            if (IsDead)
            {
                UImanager.BlinkText($"{Name}이(가) 죽었습니다.", 2, 200, ConsoleColor.DarkRed, ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"게임 오버!");
                Console.ResetColor();
                Thread.Sleep(1000);
                UImanager.EndingAnimation();
                Thread.Sleep(2000);
                Environment.Exit(0);

            }
            else Console.WriteLine($"남은 체력: {Health}");

        }

        public void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"        \u001b[48;2;30;30;30m\u001b[38;2;255;255;255m상태 보기\u001b[0m");
            Console.WriteLine();
            Console.WriteLine($"\t• 이름: {Name}");
            Console.WriteLine($"\t• LV : {Level}");
            Console.WriteLine($"\t• 직업 : {job.JobName}");
            Console.WriteLine($"\t• 공격력 : {AttackPower + WeaponStat} ( + {WeaponStat})");
            Console.WriteLine($"\t• 방어력 : {AmorDefense + AmorStat} (+ {AmorStat})");
            Console.WriteLine($"\t• 체력: {Health}");
            Console.WriteLine($"\t• GOLD: {Gold}");
            Console.WriteLine();
            Console.Write("\t\u001b[38;2;255;150;150m");
            Console.WriteLine($"0. 나가기\u001b[0m");


        }

        public int ShowInventory(bool showIdx, bool OnlyEquip)
        {


           
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Console.WriteLine();



            ItemArray(ref Inventory);

            int EquipCount = Inventory.Count(item => item is Equipment);
            int MiscellCount = EquipCount;

            for (int i = 0; i < EquipCount; i++)
            {
                Equipment targetInventory = Inventory[i] as Equipment;

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = targetInventory.IsEquipped ? "\u001b[48;2;255;255;255m\u001b[38;2;0;0;0m[E]\u001b[0m" : "";
                Console.WriteLine($"- {displayIdx}{displayEquipped} {targetInventory.EquipmentStatText()}");


            }


            if (!OnlyEquip)
            {

                for (int i = MiscellCount; i < Inventory.Count; i++)
                {
                    string displayIdx = showIdx ? $"{i + 1} " : "";
                    Console.WriteLine($"- {displayIdx} {Inventory[i].ItemInfoText()}");

                }

            }


            Console.WriteLine();
            Console.WriteLine(showIdx ?  "" : "1. 장착 / 해제 관리");
            Console.WriteLine();
            Console.WriteLine($"0. 나가기");

            return OnlyEquip ? EquipCount :Inventory.Count;
        }




        public void GetExp(int EnemyExp)
        {

            Console.WriteLine($"{EnemyExp}의 경험치를 획득했습니다.");
            Exp += EnemyExp;

            int MaxLevel = 5;
            if (Level < MaxLevel)
            {


                while (LevelUpExp[Level] < Exp)
                {

                        UImanager.BlinkText2("축하합니다. 레벨업 하였습니다.", 4, 100, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Green);
                        Console.WriteLine();

                        Level += 1;
                        Exp -= LevelUpExp[Level];

                        AttackPower += 1;
                        AmorDefense += 1;

                  

                }

            }



        }



        public void EquipItem(int TargetNum)
        {

           if (TargetNum < 0)
                return;
           
            Equipment EquipItem = Inventory[TargetNum] as Equipment;

            if (EquipItem.IsEquipped)
            {
                EquipItem.IsEquipped = false;
  

                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat -= EquipItem.Attack;
              
                }
                else
                    AmorStat -= EquipItem.Defense;

            }
            else
            {
                EquipItem.IsEquipped = true;
 
                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat += EquipItem.Attack;
                }
                else
                    AmorStat += EquipItem.Defense;
            }

            Inventory[TargetNum] = EquipItem;
        }


        public bool IsEquipped(Equipment item)
        {

            if (Inventory.Contains(item))
            {
                Equipment targetItem = Inventory[Inventory.IndexOf(item)] as Equipment;
                return targetItem.IsEquipped;
            }

            return false;
        }

        public ItemType isItemHave(string itemname)
        {

            ItemType targetItem = null;

           
                foreach (ItemType Item in Inventory)
                {

                    if (Item != null && Item.Name == itemname)
                    {
                        targetItem = Item;
                        break;
                    }

                }
          

            return targetItem;
        
        }

 

        public void AddQuest(Quest quest)
        {

            Quests.Add(quest);
            Console.WriteLine($"퀘스트 '{quest.Name}'가 추가되었습니다.");
        }

        public int ShowShop(bool showIdx)
        {

            Console.Clear();
            Console.WriteLine();
            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine("[ 보유 골드 ]\u001b[0m");
            Console.Write("\u001b[38;2;255;255;210m");
            Console.WriteLine($"{Gold}G\u001b");
            Console.WriteLine();
            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine("[ 아이템 목록 ]\u001b[0m");
            Console.WriteLine();

            for (int i = 0; i < ShopList.Count; i++)
            {
                Equipment targetInventory = ShopList[i];

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = IsEquipped(targetInventory) ? "\u001b[48;2;255;255;255m\u001b[38;2;0;0;0m[E]\u001b[0m" : "";
                Console.WriteLine($"{displayIdx}{displayEquipped}{targetInventory.EquipmentStatText()} { (targetInventory.IsPurchased ? "\u001b[48;2;255;255;255m\u001b[38;2;0;0;0m구매완료\u001b[0m" : $"\u001b[38;2;255;255;210m{targetInventory.Price} G\u001b[0m" )}");


            }

            Console.WriteLine();
            Console.WriteLine(!showIdx ? "1. 아이템구매\n2. 아이템판매" : "");
            Console.Write("\u001b[38;2;255;150;150m");
            Console.WriteLine();
            Console.WriteLine($"0. 나가기\u001b[0m");

            return ShopList.Count;


        }

        public void BuyShop(int TargetNum, Player player)
        {

            if (TargetNum < 0)
                return;

    
            Equipment targetItem = ShopList[TargetNum];


            if (targetItem.IsPurchased != true && Gold >= targetItem.Price)
            {

                ShopList[TargetNum].IsPurchased = true;
                targetItem.IsPurchased = true;
                
                Inventory.Add(targetItem);

                Gold -= targetItem.Price;


                Console.WriteLine("구매를 완료했습니다.");
                // 아이템 구매 카운트 증가
                if (player.Quests.Any(q => q is ItemPurchaseQuest))
                {
                    var purchaseQuest = player.Quests.FirstOrDefault(q => q is ItemPurchaseQuest) as ItemPurchaseQuest;
                    purchaseQuest?.ItemPurchased(); // 구매 퀘스트의 카운트 증가
                }


            }
            else if (targetItem.IsPurchased != true && Gold < targetItem.Price)
            {


                UImanager.BlinkText("Gold가 부족합니다.", 3, 100, ConsoleColor.Yellow, ConsoleColor.Red);


            }
            else if (targetItem.IsPurchased)
            {

                UImanager.BlinkText("이미 구매한 아이템입니다.", 3, 100, ConsoleColor.Blue, ConsoleColor.White);


            }

        
            Thread.Sleep(1000);
           


        }


        public void SellShop(int TargetNum)
        {


            if (TargetNum < 0)
                return;


            if (Inventory[TargetNum] is Equipment)
            {

                Equipment targetItem = Inventory[TargetNum] as Equipment;


                if (targetItem.IsEquipped)
                    Console.WriteLine("아이템을 판매할 수 없습니다. 장착을 해제한 후 다시 시도하세요.");


                else if (targetItem.IsPurchased == true)
                {

                    foreach (Equipment ShopItem in ShopList)
                    {

                        if (ShopItem.Name == targetItem.Name)
                        {

                            ShopItem.IsPurchased = false;
                            break;
                        }

                    }

                    Gold += targetItem.Price;
                    Inventory.Remove(targetItem);
                    Console.WriteLine("아이템을 판매했습니다.");

                }
                else
                {

                    Gold += targetItem.Price;
                    Inventory.Remove(targetItem);
                    Console.WriteLine("아이템을 판매했습니다.");

                }


            }

            else
            {
                ItemType targetItem = Inventory[TargetNum];


                Console.WriteLine($"해당하는 아이템의 개당 가격은 {targetItem.Price} G 입니다.");
                Console.WriteLine($"원하시는 판매 개수를 입력해주세요. 0 ~ {targetItem.HasNum}");
                int SellCount = Num.Sel(targetItem.HasNum);


                Inventory[TargetNum].HasNum -= SellCount;

                if (Inventory[TargetNum].HasNum == 0)
                    Inventory.Remove(targetItem);
                            
                Gold += targetItem.Price * SellCount;

                Console.WriteLine("아이템을 판매했습니다.");
            }
           
            Thread.Sleep(1000);

        }


        public static void QuestMenu(Player player)
        {
            Console.Clear();
            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine("진행 중인 퀘스트 목록: \u001b[0m");
            Console.WriteLine();
            for (int i = 0; i < player.Quests.Count; i++)
            {
                var quest = player.Quests[i];
                Console.WriteLine($"{i + 1}. {quest.Name} (진행 상태: {(quest.IsCompleted ? "완료" : "진행 중")})");
            }

            Console.WriteLine();
            Console.WriteLine("\n퀘스트를 완료하려면 번호를 입력하세요");
            Console.Write("\u001b[38;2;255;150;150m");
            Console.WriteLine("0. 돌아가기 \u001b[0m");
            int choice = Num.Sel(player.Quests.Count);

            if (choice > 0 && choice <= player.Quests.Count)
            {
                var selectedQuest = player.Quests[choice - 1];

                if (selectedQuest.IsCompleted)
                {
                    Console.WriteLine("보상을 받으시겠습니까?");
                    Console.WriteLine("1. 예 / 2. 아니오");
                    int rewardChoice = Num.Sel(2);

                    if (rewardChoice == 1)
                    {
                        // 보상 주고 초기화
                        selectedQuest.CompleteQuest(player);
                        Console.WriteLine($"퀘스트 '{selectedQuest.Name}'가 초기화되었습니다.");
                    }
                    else
                    {
                        // 보상 안받기 
                        Console.WriteLine($"퀘스트 '{selectedQuest.Name}'는 완료 상태입니다. 보상을 받지 않았습니다.");
                    }
                }
                else
                {
                    Console.WriteLine($"퀘스트 '{selectedQuest.Name}'는 아직 완료되지 않았습니다.");
                }
            }
            else if (choice == 0)
            {
                return;
            }
            Console.WriteLine("\n0. 돌아간다.");
        }
    }
}
