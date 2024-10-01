﻿

using System.ComponentModel;
using System.Numerics;
using static TextRPG_Team12.Quest;

namespace TextRPG_Team12
{
    public class Player : Character
    {

        public static readonly int[] LevelUpExp = { 0, 100, 350, 650, 1000};

        public List<ItemType> Inventory = new List<ItemType>();
        private static List<Equipment> EquipList = new List<Equipment>();

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
            Health = 100 +job.JobHealth;
            MaxHealth =Health;
            MaxMana = 50 + job.JobMana;
            Mana = 50 + job.JobMana;
            AttackPower = 10 +job.JobAttackPower;
            AmorDefense = 5 + job.JobAmorDeffense;
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
            Console.WriteLine($"{Name}이(가) {deDamage}의 데미지를 받았습니다.");

            Health -= deDamage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"남은 체력: {Health}");

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


            ItemArray(ref Inventory);

            int EquipCount = Inventory.Count(item => item is Equipment);
            int MiscellCount = EquipCount;

            for (int i = 0; i < EquipCount;  i++)
            {
                Equipment targetInventory = Inventory[i] as Equipment;

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = IsEquipped(targetInventory) ? "[E]" : "";
                Console.WriteLine($"- {displayIdx}{displayEquipped} {targetInventory.EquipmentStatText()}");


            }


            if (!showIdx)
            {

                for (int i = MiscellCount; i < Inventory.Count; i++)
                {
                    string displayIdx = showIdx ? $"{i + 1} " : "";
                    Console.WriteLine($"- {displayIdx} {Inventory[i].ItemInfoText()}");

                }

            }


            Console.WriteLine();
            Console.WriteLine(!showIdx ? "1. 장착관리" : "");
            Console.WriteLine($"0. 나가기");

            return !showIdx ? Inventory.Count : EquipCount;
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

                    
                        Console.WriteLine($"축하합니다. 레벨업 하였습니다.");

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

            if (IsEquipped(EquipItem))
            {
                EquipList.Remove(EquipItem);
                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat -= EquipItem.Attack;
              
                }
                else
                    AmorStat -= EquipItem.Defense;

            }
            else
            {
                EquipList.Add(EquipItem);
                if (EquipItem.Type == EquipmentType.Weapon)
                {
                    WeaponStat += EquipItem.Attack;
                }
                else
                    AmorStat += EquipItem.Defense;
            }

        }


        public bool IsEquipped(Equipment item)
        {
            return EquipList.Contains(item);
        }

        public bool isItemHave(ItemType item)
        {

            return Inventory.Contains(item);
        
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

        public void BuyShop(int TargetNum, Player player)
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
                // 아이템 구매 카운트 증가
                if (player.Quests.Any(q => q is ItemPurchaseQuest))
                {
                    var purchaseQuest = player.Quests.FirstOrDefault(q => q is ItemPurchaseQuest) as ItemPurchaseQuest;
                    purchaseQuest?.ItemPurchased(); // 구매 퀘스트의 카운트 증가
                }


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


            int EquipCount = Inventory.Count(item => item is Equipment);


            if (EquipCount <= TargetNum)
            {

                Equipment targetItem = Inventory[TargetNum] as Equipment;


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

                    // 수정 필요
                    ShopList[TargetNum].IsPurchased = false;


                    Gold += targetItem.Price;
                    Inventory.Remove(targetItem);

                    Console.WriteLine("아이템을 판매했습니다.");

                }

                else
                    Console.WriteLine("판매할 수 없는 아이템입니다.");
            }

            else
            {
                ItemType targetItem = Inventory[TargetNum];

                Console.WriteLine("원하시는 판매 개수를 입력해주세요");
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
            if (player.Quests.Count == 0)
            {
                Console.WriteLine("\n현재 진행 중인 퀘스트가 없습니다.");
                return;
            }

            while (true)
            {
                Console.WriteLine("진행 중인 퀘스트 목록:");
                for (int i = 0; i < player.Quests.Count; i++)
                {
                    var quest = player.Quests[i];
                    Console.WriteLine($"{i + 1}. {quest.Name} (진행 상태: {(quest.IsCompleted ? "완료" : "진행 중")})");
                }

                Console.WriteLine("\n퀘스트를 완료하려면 번호를 입력하세요 (0. 돌아가기):");
                int choice = Num.Sel(player.Quests.Count);

                if (choice > 0 && choice <= player.Quests.Count)
                {
                    var selectedQuest = player.Quests[choice - 1];

                    if (selectedQuest.IsCompleted)
                    {

                        Console.WriteLine("보상을 받으시겠습니까? (1. 예 / 2. 아니오)");
                        int rewardChoice = Num.Sel(2);

                        if (rewardChoice == 1)
                        {
                            // 퀘스트 완료 시 보상 지급 및 초기화
                            selectedQuest.CompleteQuest(player);
                            Console.WriteLine($"퀘스트 '{selectedQuest.Name}'가 초기화되었습니다.");
                        }
                    }
                    else
                    {
                        selectedQuest.CheckProgress(); // 진행 상황 확인

                        if (selectedQuest.IsCompleted)
                        {
                            // 퀘스트 완료 시 보상 지급
                            selectedQuest.CompleteQuest(player);
                            Console.WriteLine($"퀘스트 '{selectedQuest.Name}'를 완료하였습니다!");
                        }
                        else
                        {
                            Console.WriteLine($"퀘스트 '{selectedQuest.Name}'는 아직 완료되지 않았습니다.");
                        }
                    }
                    break;
                }
                else if (choice == 0)
                {
                    Console.WriteLine("메인 메뉴로 돌아갑니다.");
                    Program.village(player); // 마을로 돌아가기
                    break;
                }
            }

            Num.Sel(0);
        }







    }

}
