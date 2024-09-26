using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextRPG_Team12
{
    internal class SaveLoad
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;

        public void SaveData(Player player)
        {
            string playerData = JsonConvert.SerializeObject(player);
            File.WriteAllText(path + "\\PlayerData.json", playerData);
        }

        public void LoadData(Player player)
        {
            if (!File.Exists(path + "\\PlayerData.json"))
            {
                return;
            }

            else
            {
                string playerLoadData = File.ReadAllText(path + "\\PlayerData.json");
                player = JsonConvert.DeserializeObject<Player>(playerLoadData);
            }
        }




    }
}
