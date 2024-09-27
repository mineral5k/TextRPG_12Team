using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Monster : Character
    {


        public void SetUpEnemy(int Stagelevel)
        {
            Level = Stagelevel;
            Health *= (int)Math.Pow(1.15, Stagelevel - 1);
            AttackPower *= (int)Math.Pow(1.15, Stagelevel - 1);

            // Dungeon에 있는 SetUpEnemy() 
            //    enemyHealth = (int) (baseEnemyHealth* Math.Pow(1.15, stage - 1));  // 15% 증가
            //    enemyAttackDamage = (int)(baseEnemyAttackDamage * Math.Pow(1.15, stage - 1));  // 15% 증가

        }




    }


}
