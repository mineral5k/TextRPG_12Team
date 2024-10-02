using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextRPG_Team12
{
    public class SaveLoad
    {
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


        }

        public void LoadData(ref Player player, ref Job job)
        {
            if (!File.Exists(path + "\\PlayerData.json"))
            {
                
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




            }
        }




    }
}
