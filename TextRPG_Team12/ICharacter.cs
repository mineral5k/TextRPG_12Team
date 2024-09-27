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

        int Level { get; set; }
        int Health { get; set; }

        int AttackPower { get; set; }

        bool IsDead { get; }

        int Exp { get; set; }


        public void TakeDamage(int damage, string EnemyName);

     



    }
}
