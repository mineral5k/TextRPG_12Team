using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    public class Stage
    {
        int clearedFloor = 0;

        public void Dungeon(Player player)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("도전할 스테이지를 선택하세요");
            Console.WriteLine($"현재 도전 가능 스테이지 :1 ~ {clearedFloor+1}" );
            Console.WriteLine("0. 나가기");


            int sel = Num.Sel(clearedFloor + 1);
            if (sel != 0)
            {
                EnterTheDungeon(sel, player);
            }
            

        }


        public void EnterTheDungeon(int floor, Player player)
        {
            int numberOfEnemy = new Random().Next(floor,5);
            Monster[] enemy = new Monster[numberOfEnemy];

            for (int i = 0; i< numberOfEnemy; i++)
            {
               int TypeOfEnemy =new Random().Next(1,4);

                switch (TypeOfEnemy)
                {
                    case 1:
                        enemy[i] = new Goblin();
                        break;
                    case 2:
                        enemy[i] = new Trol();
                        break;
                    case 3:
                        enemy[i] = new Dragon();
                        break;
                }
                
            }
            Battle(player, enemy);
        }

        public void Battle(Player player, Monster[] enemy)
        {
            while (true)
            {
                bool enemyAllDead = true;                                  //적이 모두 죽었는지 체크하는 bool
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemyAllDead = (enemyAllDead) && (enemy[i].IsDead);          // 적중에 하나라도 isDead가 false 라면 allDead는 false가 된다.
                }

                if (enemyAllDead)
                {
                    Victory(player);
                }
                else
                {
                    BattlePlayerTurn(player, enemy);
                }

                enemyAllDead = true;
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemyAllDead = (enemyAllDead) && (enemy[i].IsDead);          // 적중에 하나라도 isDead가 false 라면 allDead는 false가 된다.
                }

                if (enemyAllDead)
                {
                    break;
                }
                else
                {
                    BattleEnemyTurn(player, enemy);
                }







            }
        }


        void Victory(Player player)
        {

        }


        void BattleEnemyTurn(Player player, Monster[] enemy)
        {

        }














        void BattlePlayerTurn (Player player, Monster[] enemy)
        {
            ShowSituation(player, enemy);
            Console.WriteLine("1. 공격한다");
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine("3. 아이템 사용");
            Console.WriteLine("0. 도망간다");

            int sel = Num.Sel(3);

            switch (sel)
            {
                case 0:
                    Run();
                    break;
                case 1:
                    AttackSellect(player , enemy);
                    break;
                case 2:
                    UseItem();
                    break;
                case 3:
                    UseSkill(player, enemy);
                    break;
            }
           

            

        }

        void Run()
        {
            Console.WriteLine("전투에서 도망쳤다!");
            Console.WriteLine("마을로 돌아갑니다");
            
        }

        void AttackSellect(Player player, Monster[] enemy)
        {
            ShowSituationNumber(player, enemy); 
            Console.WriteLine("0. 취소");

            int sel = Num.Sel(enemy.Length);
            bool repeat = false;
            do
            {
                repeat = false;
                if (sel == 0)
                {
                    BattlePlayerTurn(player, enemy);
                }
                else if (enemy[sel-1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    player.Attack(enemy[sel-1]);
                }
            } while (repeat);

        }
        void UseItem()
        {

        }
        void UseSkill(Player player, Monster[] enemy)
        {
            ShowSituation(player, enemy);
            Console.WriteLine($"1. {player.job.JobSkillName1}  {player.job.JobSkillDesc1}");
            Console.WriteLine($"2. {player.job.JobSkillName2}  {player.job.JobSkillDesc2}");
            Console.WriteLine($"3. {player.job.JobSkillName3}  {player.job.JobSkillDesc3}");
            Console.WriteLine("0. 취소");
            int sel = Num.Sel(3);

            switch (sel)
            {
                case 0:
                    BattlePlayerTurn(player, enemy); 
                    break;
                case 1:
                    player.job.JobSkill_1();
                    break;
                case 2:
                    player.job.JobSkill_2();
                    break;
                case 3:
                    player.job.JobSkill_3();
                    break;
            }

            
        }


        void ShowSituation(Player player, Monster[] enemy)
        {
            Console.Clear();
            Console.WriteLine("전투 !! ");
            Console.WriteLine();
            for (int i = 0; i < enemy.Length; i++)                                                         //적 정보와 HP 표시
            {
                if (enemy[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"LV.{enemy[i].Level} {enemy[i].Name} Dead");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"LV.{enemy[i].Level} {enemy[i].Name}  HP {enemy[i].Health}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[내 상태]");
            Console.WriteLine($"LV.{player.Level}   {player.Name}  직업 : {player.job.JobName}");
            Console.WriteLine();
        }


        void ShowSituationNumber(Player player, Monster[] enemy)
        {
            Console.Clear();
            Console.WriteLine("전투 !! ");
            Console.WriteLine();
            for (int i = 0; i < enemy.Length; i++)                                                         //적 정보와 HP 표시
            {
                if (enemy[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{i + 1}. LV.{enemy[i].Level} {enemy[i].Name} Dead");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i + 1}. LV.{enemy[i].Level} {enemy[i].Name}  HP {enemy[i].Health}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[내 상태]");
            Console.WriteLine($"LV.{player.Level}   {player.Name}  직업 : {player.job.JobName}");
            Console.WriteLine();

        }


















    }
}
