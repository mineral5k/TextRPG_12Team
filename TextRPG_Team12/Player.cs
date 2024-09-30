

namespace TextRPG_Team12
{
    public class Player : Character
    {

        public static readonly int[] LevelUpExp = { 0, 10, 35, 65, 100 };

        private static List<Equipment> Inventory = new List<Equipment>();
        private static List<Equipment> EquipList = new List<Equipment>();
        public List<Quest> Quests { get; private set; }

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
            Quests = new List<Quest>();

        }

        public void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"LV : {Level}");
            Console.WriteLine($"직업 : {job.JobName}");
            Console.WriteLine($"공격력 : {AttackPower}");
            Console.WriteLine($"방어력 : {AmorDefense}");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"GOLD: {Gold}");
            Console.WriteLine();
            Console.WriteLine($"0. 나가기");


        }

        public void ShowInventory(bool showIdx)
        {

            Console.Clear();

            for (int i = 0; i < Inventory.Count;  i++)
            {
                Equipment targetInventory = Inventory[i];

                string displayIdx = showIdx ? $"{i + 1} " : "";
                string displayEquipped = IsEquipped(targetInventory) ? "[E]" : "";
                Console.WriteLine($"- {displayIdx}{displayEquipped} {targetInventory.EquipmentStatText()}");

          
            }

            Console.WriteLine($"0. 나가기");
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



        public void EquipItem(Equipment EquipItem)
        {


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

        public void AddQuest(Quest quest)
        {
            
            Quests.Add(quest);
            Console.WriteLine($"퀘스트 '{quest.Name}'가 추가되었습니다.");
        }

        
        public static void QuestMenu(Player player)
        {

            if (player.Quests.Count == 0)
            {
                Console.WriteLine("현재 진행 중인 퀘스트가 없습니다.");
            }
            else
            {
                Console.WriteLine("진행 중인 퀘스트 목록:");
                for (int i = 0; i < player.Quests.Count; i++)
                {
                    var quest = player.Quests[i];
                    Console.WriteLine($"{i + 1}. {quest.Name} (진행 상태: {(quest.IsCompleted ? "완료" : "진행 중")})");
                }

                Console.WriteLine("\n퀘스트를 완료하려면 번호를 입력하세요 (0으로 돌아가기):");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                if (choice > 0 && choice <= player.Quests.Count)
                {
                    var selectedQuest = player.Quests[choice - 1];
                    if (selectedQuest.IsCompleted)
                    {
                        Console.WriteLine($"퀘스트 '{selectedQuest.Name}'는 이미 완료되었습니다.");
                    }
                    else
                    {
                        selectedQuest.CheckProgress(); // 퀘스트 진행 상황 확인
                        Console.WriteLine($"퀘스트 '{selectedQuest.Name}'를 완료하였습니다!");
                    }
                }
                else if (choice == 0)
                {
                    Console.WriteLine("메인 메뉴로 돌아갑니다.");
                }
                else
                {
                    Console.WriteLine("유효하지 않은 선택입니다.");
                }
            }

            Console.WriteLine("0. 돌아가기");
            Num.Sel(0); // 사용자에게 돌아갈 수 있는 선택지 제공
        }
    }

}
