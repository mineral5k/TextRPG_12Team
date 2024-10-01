﻿using System;
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
            Console.Clear();                                                            //클리어 한 스테이지의 다음 스테이지 까지 도전 가능
            Console.WriteLine("");
            Console.WriteLine("도전할 스테이지를 선택하세요");
            Console.WriteLine($"현재 도전 가능 스테이지 :1 ~ {clearedFloor + 1}");
            Console.WriteLine("0. 나가기");


            int sel = Num.Sel(clearedFloor + 1);
            if (sel != 0)
            {
                EnterTheDungeon(sel, player);                                           //선택한 스테이지에 따라 난이도가 달라짐
            }

        }


        public void EnterTheDungeon(int floor, Player player)
        {
            int numberOfEnemy = new Random().Next(floor, 5);                             //적의 수는 선택한 스테이지 숫자~4 마리 중 랜덤
            Monster[] enemy = new Monster[numberOfEnemy];

            for (int i = 0; i < numberOfEnemy; i++)                                      // 적의 종류는 랜덤 (추후 스테이지에 따라 난이도 조절 필요)
            {
                int TypeOfEnemy = new Random().Next(1, 4);

                switch (TypeOfEnemy)
                {
                    case 1:
                        enemy[i] = new Goblin(floor);
                        break;
                    case 2:
                        enemy[i] = new Trol(floor);
                        break;
                    case 3:
                        enemy[i] = new Dragon(floor);
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
                    break;                                                  //적이 모두 죽었다면 루프에서 빠져나와 Victory 메서드를 실행
                }
                else
                {
                    BattlePlayerTurn(player, enemy);
                    Console.WriteLine("0.다음으로");
                    Num.Sel(0);                                             //전투 로그를 확인 할 수 있게 해주는 작업 
                    Console.Clear();
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
                    Console.WriteLine("0.다음으로");
                    Num.Sel(0);
                    Console.Clear();

                }

            }

            Victory(player, enemy);                                         // 플레이어가 죽은 경우
                                                                            // 플레이어 클래스에서 게임 오버로 프로그램이 종료하기 때문에 이 클래스에서 따로 메서드를 만들어 두진 않는다.
        }


        void Victory(Player player, Monster[] enemy)
        {
            Console.Clear();
            Console.WriteLine("전투에서 승리했습니다.");
            Console.WriteLine();
            int exp = 0;                                                //승리 시 적에게 할당된 경험치 획득
            int gold = 0;

            for (int i = 0; i < enemy.Length; i++)
            {
                exp += enemy[i].HuntExp;
                gold += enemy[i].LootMoney;

            }


            Console.WriteLine($"{gold}만큼의 골드를 확득했습니다.");

            player.GetExp(exp);

            // StageCleared 퀘스트 완료 불러오기

            player.Gold += gold;




            Console.WriteLine("마을로 돌아갑니다.");
            Console.WriteLine("0. 확인.");
            Num.Sel(0);

        }


        void BattleEnemyTurn(Player player, Monster[] enemy)            //적의 턴
        {
            if (player.EvadeBuff)
            {
                player.Evasion += 100;
            }
            for (int i = 0;i < enemy.Length;i++)                        
            {
                if (!enemy[i].IsDead)                                   //죽지 않은 적들이 플레이어 공격
                {
                    if (enemy[i].stun > 0)
                    {
                        Console.WriteLine($"{enemy[i].Name}은 기절하여 움직일 수 없다!");
                        enemy[i].stun--;
                    }
                    else
                    {
                        enemy[i].Attack(player);
                        if (player.Counter == true)
                        {
                            Console.WriteLine($"{player.Name}의 반격");
                            player.Attack(enemy[i]);
                        }
                    }

                    if (enemy[i].PoisonTurn > 0)
                    {
                        Console.Write("독으로 인해 ");
                        enemy[i].TakeDamage(enemy[i].PoisonDamage);
                        enemy[i].PoisonTurn--;
                    }

                }
            }
            player.Counter = false;
            if (player.EvadeBuff)
            {
                player.EvadeBuff = false;
                player.Evasion -= 100;
            }
        }


        public void BattlePlayerTurn (Player player, Monster[] enemy)
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
                    AttackSellect(player, enemy);
                    break;
                case 2:
                    UseSkill(player, enemy);

                    break;
                case 3:
                    UseItem(player, enemy);
                    break;
            }

        }

        void Run()
        {
            Console.Clear();
            Console.WriteLine("전투에서 도망쳤다!");
            Console.WriteLine("마을로 돌아갑니다");

        }

        void AttackSellect(Player player, Monster[] enemy)                                             //공격할 적을 선택하는 메서드
        {
            ShowSituationNumber(player, enemy);
            Console.WriteLine("0. 취소");


            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    BattlePlayerTurn(player, enemy);
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    player.Attack(enemy[sel - 1]);
                }
            } while (repeat);

        }
        void UseItem(Player player, Monster[] enemy)                                               //아이템 사용 메서드
        {                                                                                          //자세한 내용 추후 구현 필요
            ShowSituation(player, enemy);
            Console.WriteLine("1. 체력 포션 ");
            Console.WriteLine("2. 마나 포션 ");
            Console.WriteLine("0. 취소 ");

            int sel = Num.Sel(2);

            switch (sel)
            {
                case 0:
                    BattlePlayerTurn(player, enemy);
                    break;
                case 1:

                    break;
                case 2:

                    break;
            }


        }
        void UseSkill(Player player, Monster[] enemy)                                              //스킬 사용 메서드 
        {                                                                                          //상세한 내용은 각 직업 스킬에서 구현
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
                    player.job.JobSkill_1(player, enemy);
                    break;
                case 2:
                    player.job.JobSkill_2(player, enemy);
                    break;
                case 3:
                    player.job.JobSkill_3(player, enemy);
                    break;
            }


        }


        void ShowSituation(Player player, Monster[] enemy)                                              //적과 나의 상태를 표시해주는 메서드 
        {
            Console.Clear();
            Console.WriteLine("전투 !! ");
            Console.WriteLine();
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
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


        void ShowSituationNumber(Player player, Monster[] enemy)                                            //적과 나의 상태를 표시해주는 메서드 
        {                                                                                                   //추가로 적을 지정할 수 있는 숫자 표시도 해줌
            Console.Clear();
            Console.WriteLine("전투 !! ");
            Console.WriteLine();
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
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
