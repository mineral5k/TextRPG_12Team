﻿using System.Reflection.Metadata;

namespace TextRPG_Team12
{
    public class Player : Character
    {

        public static readonly int[] LevelUpExp = { 0, 10, 35, 65, 100 };


        Job job = new Job();

  
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
            if (LevelUpExp[Level] < Exp)
            {
                Console.WriteLine($"축하합니다. 레벨업 하였습니다.");

                Level += 1;
                Exp -= LevelUpExp[Level];

                AttackPower += 1;
                AmorDefense += 1;
                
            }


        }



    }
}
