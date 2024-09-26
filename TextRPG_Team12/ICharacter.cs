using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    public interface ICharacter
    {

        
        
        string Name { get; }

        int level { get; }
        int Health { get; set; }
        int AttackPower { get; set; }


        public void TakeDamage() {

            int a;
        
        }

    }


    public class Player : ICharacter
    {

        public string Name { get; }
        public int level { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public void TakeDamage()
        { 
        
        
        
        }


    }


    public class Monster : ICharacter
    {
     

       
        public string Name { get; }
        public int level { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

  



    }
}
