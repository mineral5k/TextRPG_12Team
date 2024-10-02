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
        }

        public void LoadData(ref Player player, ref Job job)
        {
            if (!File.Exists(path + "\\PlayerData.json"))
            {
                return;
            }

            else
            {
                string jobLoadData = File.ReadAllText(path + "\\JobData.json");
                job = JsonConvert.DeserializeObject<Job>(jobLoadData);
                player.job = job;

                string playerLoadData = File.ReadAllText(path + "\\PlayerData.json");
                player = JsonConvert.DeserializeObject<Player>(playerLoadData);
                
            }
        }




    }
}
