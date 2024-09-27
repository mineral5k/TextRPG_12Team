using System.Reflection.Metadata;

namespace TextRPG_Team12
{
    public class Player : ICharacter
    {

        public static readonly int[] LevelUpExp = { 0, 10, 35, 65, 100 };



        public string Name { get; }

        Job job = new Job();

        public int Level { get; set; }
        public int Health { get; set; }

        public int Gold { get; set; }

        public float AttackPower { get; set; }

        public int WeaponStat { get; set; }
        public int AmorStat {get; set; }

        public int AmorDefense { get; set; }

        public bool IsDead => Health <= 0;

        public int Exp { get; set;}

        public int Mana { get; set;}

       


        public void TakeDamage(int damage, string EnemyName)
        {

            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) {EnemyName}(으)로 부터 데미지를 받아 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {EnemyName}(으)로 부터 {damage}의 데미지를 받았습니다. 남은 체력: {Health}");


        }



        public Player(string name, Job inputJob)
        {
            Name = name;
            job = inputJob;  
            Level = 1;
            Gold = 1500;
            Health = 100 +job.JobHealth;
            Mana = 50 + job.JobMana;
            AttackPower = 10 +job.JobAttackPower;
            AmorDefense = 5 + job.JobAmorDeffense;

        }


        
        public void GetExp(int EnemyExp)
        {

            Console.WriteLine($"{EnemyExp}의 경험치를 획득했습니다.");
            Exp += EnemyExp;
            if (LevelUpExp[Level] > Exp)
            {
                Console.WriteLine($"축하합니다. 레벨업 하였습니다.");

                Level += 1;
                Exp -= LevelUpExp[Level];

                AttackPower += 0.5f;
                AmorDefense += 1;
                
            }


        }



    }
}
