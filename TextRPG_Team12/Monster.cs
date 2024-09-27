﻿using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : ICharacter
    {


        public string Name { get; }
        public int Level { get; set; }
        public int Health { get; set; }
        public float AttackPower { get; set; }

        public bool IsDead => Health <= 0;

        public int Exp { get; set; }



        public void TakeDamage(int damage, string EnemyName)
        {

            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {EnemyName}(으)로 부터 {damage}의 데미지를 받았습니다. 남은 체력: {Health}");


        }

        
        public Monster(string name, int level, int health)
        {


            //초기 기본 스텟
            Level = level;
            Name = name;
            Health = health;
            Exp = level; 


        }



    }
}
