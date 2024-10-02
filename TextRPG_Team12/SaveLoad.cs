using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static TextRPG_Team12.Quest;

namespace TextRPG_Team12
{


    public class SaveLoad
    {
        public static List<Equipment> EquipmentDb;
        public static string path = AppDomain.CurrentDomain.BaseDirectory;

        public void SaveData( Player player, Job job)
        {
            string playerData = JsonConvert.SerializeObject(player);
            File.WriteAllText(path + "\\PlayerData.json", playerData);

            string jobData = JsonConvert.SerializeObject(job);
            File.WriteAllText(path + "\\JobData.json", jobData);

            string shopList = JsonConvert.SerializeObject(player.ShopList);
            File.WriteAllText(path + "\\ShopListData.json", shopList);

            string equipList = JsonConvert.SerializeObject(player.EquipList);
            File.WriteAllText(path + "\\EquipListData.json", equipList);
            List<Equipment> saveInv = new List<Equipment>(); 
            for (int i = 0; i < player.Inventory.Count(); i++)
            {
                saveInv.Add(player.Inventory[i] as Equipment);
            }

            string inventoryList = JsonConvert.SerializeObject(saveInv);
            File.WriteAllText(path + "\\InventoryListData.json", inventoryList);


            string stageData = JsonConvert.SerializeObject(player.stage);
            File.WriteAllText(path + "\\StageData.json", stageData);


        }

        public void LoadData(ref Player player, ref Job job,IScene currentScene)
        {
            if (!File.Exists(path + "\\PlayerData.json"))
            {
                Console.Clear();
                currentScene.OnShow();
                string name = currentScene.Name;
                bool repeat = false;
                // 번호 받아서 직업으로 배정  
                do
                {
                    repeat = false;

                    int choice = Num.Sel(4);
                    switch (choice)
                    {

                        case 0:
                            Console.WriteLine("잘못된 입력입니다");
                            repeat = true;
                            break;
                        case 1:
                            player = new Player(name, new Worrior());
                            break;
                        case 2:
                            player = new Player(name, new Archer());
                            break;
                        case 3:
                            player = new Player(name, new Thief());
                            break;
                        case 4:
                            player = new Player(name, new Mage());
                            break;
                    }
                } while (repeat);

                EquipmentData();
                player.ShopList = EquipmentDb;

                MonsterKillQuest monsterKillQuest = new MonsterKillQuest(5);  // 목표 몬스터 처치 수 5
                player.AddQuest(monsterKillQuest);

                StageClearQuest stageClearQuest = new StageClearQuest();  // 던전 클리어 목표
                player.AddQuest(stageClearQuest);

                ItemPurchaseQuest itemPurchaseQuest = new ItemPurchaseQuest(3);
                player.AddQuest(itemPurchaseQuest);
                monsterKillQuest.stage = player.stage;

            }

            else
            {
                string jobLoadData = File.ReadAllText(path + "\\JobData.json");
                job = JsonConvert.DeserializeObject<Job>(jobLoadData);
                player.job = job;

                string playerLoadData = File.ReadAllText(path + "\\PlayerData.json");
                player = JsonConvert.DeserializeObject<Player>(playerLoadData);

                string shopListLoadData = File.ReadAllText(path + "\\ShopListData.json");
                player.ShopList = JsonConvert.DeserializeObject<List<Equipment>>(shopListLoadData);

                string equipListLoadData = File.ReadAllText(path + "\\EquipListData.json");
                player.EquipList = JsonConvert.DeserializeObject<List<Equipment>>(equipListLoadData);

                List<Equipment> saveInv = new List<Equipment>();
                string inventoryListLoadData = File.ReadAllText(path + "\\InventoryListData.json");
                saveInv = JsonConvert.DeserializeObject<List<Equipment>>(inventoryListLoadData);
                player.Inventory = new List<ItemType>();
                for (int i = 0; i < saveInv.Count(); i++)
                {
                    player.Inventory.Add(saveInv[i]);
                }


                string stageLoadData = File.ReadAllText(path + "\\StageData.json");
                player.stage = JsonConvert.DeserializeObject<Stage>(stageLoadData);




            }
        }




        static void EquipmentData()
        {
            EquipmentDb = new List<Equipment>
            {
            new Equipment("훈련용 갑옷", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
            new Equipment("강철 갑옷", "강철로 제작된 튼튼한 갑옷입니다.", 9, 0, 2000, EquipmentType.Armor),
            new Equipment("멋쟁이 갑옷", "멋과 방어력 모두 챙긴 갑옷입니다.", 15, 0, 3500, EquipmentType.Armor),
            new Equipment("고블린의 목걸이", "고블린들이 애타게 찾고 있는 목걸이입니다. 작은 힘이 깃들어 있습니다.", 0, 2, 600, EquipmentType.Weapon),
            new Equipment("트롤의 반지", "트롤의 힘을 담은 반지로, 착용한 자에게 강력한 힘을 부여합니다.", 0, 5, 1500, EquipmentType.Weapon),
            new Equipment("드래곤의 이빨", "드래곤의 이빨로 만들어진 무기로, 소지 시 드래곤의 기운이 전해집니다.", 0, 7, 2500, EquipmentType.Weapon),
            };


        }
    }
}
