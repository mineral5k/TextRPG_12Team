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



        public void TakeDamage(int damage, string EnemyName)
        {

            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {EnemyName}(으)로 부터 {damage}의 데미지를 받았습니다. 남은 체력: {Health}");


        }





    }
}
