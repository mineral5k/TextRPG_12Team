using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : Character
    {

        public enum MonsterType { goblin , Trol, dragon }
        public MonsterType[] monsterName;



        public string Name { get; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public bool IsDead => Health <= 0;

        public int Exp { get; set; }




        
        public Monster(int level, int health)
        {


            Random ran = new Random();
            int MonsterName = ran.Next(monsterName.Length);
 
            Level = level;
            Name = monsterName[MonsterName].ToString();
            Health = health;
            Exp = level; 


        }



    }


    public class Golbin { 
    
    
    
    
    }

    public class Dragon { 
    
    

    }


    public class Trol { 
    
    
    
    }
}
