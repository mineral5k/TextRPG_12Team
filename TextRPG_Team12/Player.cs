namespace TextRPG_Team12
{
    public class Player : ICharacter
    {

        public static readonly int[] LevelUpExp = {0, 10, 35, 65, 100};
     


        public string Name { get; }

        public string Job{ get; set;}

        public int Level { get; set; }
        public int Health { get; set; }
        
        public int Gold { get; set; }
        
        public float AttackPower { get; set; }

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



        public Player(string name, string job, int JobHealth, int JobAmorDefense, int JobAttackPower, int JobMana) {

            // 초기 기본 스텟 설정 
            Name = name;
            Job = job;  
            Health = JobHealth;
            Level = 1;
            Mana = JobMana;
            AmorDefense = JobAmorDefense;
            AttackPower = JobAttackPower;
            Gold = 1500;

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
