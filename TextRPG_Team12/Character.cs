using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    public class Character
    {


       public string Name { get; set; }

       public int Level { get; set; }

       public int Health { get; set; }

       public int AttackPower { get; set; }
       
       public bool IsDead => Health <= 0;
       

     
       public int Evasion { get; }
     
       public int Critical { get;  }



        public void TakeDamage(int damage)
        {

            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");

        }

        public void Attack(Character character)
        {
            int r = (AttackPower % 10 == 0) ? (AttackPower / 10) : (AttackPower / 10 + 1);
            int damage = new Random().Next(AttackPower - r, AttackPower + r + 1);

            Console.WriteLine($"{Name}의 공격!");
            character.TakeDamage(damage);
        }



    }
}
