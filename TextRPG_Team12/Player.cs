namespace TextRPG_Team12
{
    public class Player : ICharacter
    {

        public string Name { get; }

        public string Job{ get; set;}

        public int Level { get; }
        public int Health { get; set; }
        
        public int Gold { get; set; }
        
        public int AttackPower { get; set; }

        public int AmorDefense { get; set; }

        public bool IsDead { get; set; }

        public int Mana { get; set;}



        public void TakeDamage(int damage, string EnemyName)
        {

            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
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


    }
}
