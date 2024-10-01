using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_Team12
{
    public class Job
    {
        public string JobName { get; set; }
        public int JobHealth { get; set; }
        public int JobMana { get; set; }
        public int JobAttackPower { get; set; }
        public int JobAmorDeffense { get; set; }
        public string JobSkillName1 { get; set; }
        public string JobSkillDesc1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillDesc2 { get; set; }
        public string JobSkillName3 { get; set; }
        public string JobSkillDesc3 { get; set; }



        public virtual void JobSkill_1(Player player, Monster[] enemy)
        {

        }

        public virtual void JobSkill_2(Player player, Monster[] enemy)
        {

        }

        public virtual void JobSkill_3(Player player, Monster[] enemy)
        {

        }

        protected void ShowSituation(Player player, Monster[] enemy)                                              //적과 나의 상태를 표시해주는 메서드 
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


        protected void ShowSituationNumber(Player player, Monster[] enemy)                                            //적과 나의 상태를 표시해주는 메서드 
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

    public class Worrior : Job
    {


        public Worrior()
        {
            JobName = "전사";
            JobHealth = 0;
            JobMana = 0;
            JobAttackPower = 0;
            JobAmorDeffense = 0;
            JobSkillName1 = "파워어택";
            JobSkillDesc1 = "한 명의 적에게 공격력의 150%의 공격을 가합니다.";
            JobSkillName2 = "파워 슬래시";
            JobSkillDesc2 = "전체 적들에게 공격력의 80%의 공격을 가합니다.";
            JobSkillName3 = "반격";
            JobSkillDesc3 = "한 턴동안 적에게 공격 받으면 반격합니다.";

        }



        public override void JobSkill_1(Player player, Monster[] enemy)
        {
            // 파워 어택: 한 명의 적에게 공격력의 1.5배 공격
            // 공격 대상 선택 구현 ?
            //int damage = (int)(JobAttackPower * 1.5);
            //Console.WriteLine($"{JobSkillName1}! 적에게 {damage}의 데미지를 입혔습니다! ");
            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower * 1.5);
            ShowSituationNumber(player, enemy);

            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                     Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
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
            player.AttackPower = temp;

        }

        public override void JobSkill_2(Player player, Monster[] enemy)
        {
            // 파워 슬래시: 전체 적들에게 공격력의 0.8배 공격
            // 전체 공격
            //int damage = (int)(JobAttackPower * 0.8);
            //Console.WriteLine($"{JobSkillName2}! 적들에게 {damage}의 데미지를 입혔습니다!");
            Console.Clear();
            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower * 0.8);

            for(int i = 0; i < enemy.Length; i++)
            {
                if (!enemy[i].IsDead)
                {
                    player.Attack(enemy[i]);
                }
            }
            player.AttackPower = temp;

        }

        public override void JobSkill_3(Player player, Monster[] enemy)
        {
            
            Console.WriteLine($"반격을 위한 자세를 잡았습니다.");              
            player.Counter = true;
        }

    }

    public class Archer : Job
    {

        private int poisonDamage;
        private int poisonTurns;

        public Archer()
        {
            JobName = "궁수";
            JobHealth = 0;
            JobMana = 0;
            JobAttackPower = 0;
            JobAmorDeffense = 0;
            JobSkillName1 = "속사";
            JobSkillDesc1 = "한 명의 적에게 50%의 공격력으로 3번의 공격을 가합니다.";
            JobSkillName2 = "독화살";
            JobSkillDesc2 = "한 명의 적에게 3턴 동안 지속되는 상처를 남깁니다. 상처는 공격력의 66%에 해당하는 데미지를 줍니다.";
            JobSkillName3 = "화살비";
            JobSkillDesc3 = "모든 적에게 화살을 퍼붓습니다. 화살의 데미지는 생존 중인 적의 수에 따라 달라집니다.";
        }



        public override void JobSkill_1(Player player, Monster[] enemy)
        {
            // 속사 : 한 명의 적에게 공격력의 0.5배로 3회 공격
            // 공격 대상 선택 구현 ?
            // 타수마다 치명타가 존재하면 ?
            // 최종 데미지 표기 방식 확인 부탁드립니다 
            // int damage = (int)(JobAttackPower * 0.5);

            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower * 0.5);

            ShowSituationNumber(player, enemy);
            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < 3; i++)            // 3회 연속 공격
                    {
                        player.Attack(enemy[sel-1]);    
                        if (enemy[sel - 1].IsDead) break;  //중간에 적이 사망하면 중지   
                    }
                }
            } while (repeat);

            player.AttackPower = temp;

        }

        public override void JobSkill_2(Player player, Monster[] enemy)
        {
            // 독화살: 한 명의 적에게 3턴 동안 지속되는 상처를 남깁니다.
            // 공격 대상 선택 구현 ?
            ShowSituationNumber(player, enemy);

            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.WriteLine($"{enemy[sel-1].Name}이 중독되었습니다.");
                    enemy[sel - 1].PoisonTurn += 3;
                    enemy[sel -1].PoisonDamage = (int)Math.Round(player.AttackPower * 0.66);
                }
            } while (repeat);
        }

        public override void JobSkill_3(Player player, Monster[] enemy)
        {
            // 화살비: 모든 적에게 화살을 퍼붓습니다.
            // 전체 공격 
            int numberOfEnemies = 0; // 적의 수 정보를 받아와야합니다.
            //int damage = (int)(JobAttackPower * 2.5 / numberOfEnemies);
            //Console.WriteLine($"{JobSkillName3}! {numberOfEnemies}명의 적에게 {damage}의 데미지를 입혔습니다!");
            Console.Clear();
            for (int i = 0; i < enemy.Length; i++)
            {
                if (!enemy[i].IsDead)
                {
                    numberOfEnemies++;                                       //죽지 않은 적의 수
                }
            }

            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower *2.5 / numberOfEnemies);
            for (int i = 0; i < enemy.Length; i++)                          //모든 적을 공격
            {
                if (!enemy[i].IsDead)
                {
                    player.Attack(enemy[i]);
                }
            }
            player.AttackPower = temp;
        }

    }

    public class Thief : Job
    {


        public Thief()
        {
            JobName = "도적";
            JobHealth = 0;
            JobMana = 0;
            JobAttackPower = 0;
            JobAmorDeffense = 0;
            JobSkillName1 = "기습";
            JobSkillDesc1 = "80%의 공격력으로 적에게 두번의 기습적인 공격을 가합니다.";
            JobSkillName2 = "은신";
            JobSkillDesc2 = "이번 턴 적들의 공격을 100%로 회피합니다.";
            JobSkillName3 = "흡혈";
            JobSkillDesc3 = "적에게 공격력의 110%의 피해를 주고 데미지의 50%에 해당하는 체력을 흡수합니다.";
        }



        public override void JobSkill_1(Player player, Monster[] enemy)
        {

            // 타수 마다 치명타 적용 ?
            // 최종 데미지 표기 확인 부탁드립니다 .
            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower * 0.8);

            ShowSituationNumber(player, enemy);
            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < 2; i++)            // 2회 연속 공격
                    {
                        player.Attack(enemy[sel - 1]);
                        if (enemy[sel - 1].IsDead) break;  //중간에 적이 사망하면 중지   
                    }
                }
            } while (repeat);

            player.AttackPower = temp;

        }

        public override void JobSkill_2(Player player, Monster[] enemy)
        {
            // 은신: 적의 다음 공격을 100% 회피
            // 회피율 변수가 적용되면 구현 부탁드립니다 .
            Console.WriteLine($"회피 자세를 취하여 한 턴동안 공격을 회피합니다");            //플레이어 클래스 조정 필요 
            player.EvadeBuff = true;
           
        }

        public override void JobSkill_3(Player player, Monster[] enemy)
        {
            // 흡혈: 적에게 공격력의 110% 피해를 주고 체력 회복
            int temp = player.AttackPower;
            int blood = 0;
            player.AttackPower = (int)Math.Round(player.AttackPower * 1.1);
            ShowSituationNumber(player, enemy);

            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    blood = enemy[sel - 1].Health;        //공격 전 적의 피
                    player.Attack(enemy[sel - 1]);
                    blood -= enemy[sel - 1].Health;       //흡혈량 : (공격 전 적의 HP -공격 후 적의 HP) = 준 데미지 
                }
            } while (repeat);
            player.AttackPower = temp;
            player.Health += blood;
            Console.WriteLine($"{blood}의 체력을 회복했습니다");
        }
    }
    public class Mage : Job
    {


        public Mage()
        {
            JobName = "마법사";
            JobHealth = 0;
            JobMana = 0;
            JobAttackPower = 0;
            JobAmorDeffense = 0;
            JobSkillName1 = "체인 쇼스";
            JobSkillDesc1 = "최대 3명의 적을 연속하여 공격하는 마법을 시전한다. 데미지는 적중할 때마다 일정하게 감소한다.";
            JobSkillName2 = "스턴";
            JobSkillDesc2 = "적에게 기절 마법을 시전한다. 공격력의 130%의 피해를 입히고 33%로 기절시킨다.";
            JobSkillName3 = "죽음";
            //50%는 사기인거 같고 33%는 조금 약한거 같고 , 수치 확인 후 조정 부탁드립니다 .
            JobSkillDesc3 = "체력이 33% 이하인 적을 즉사시킨다.";
        }



        public override void JobSkill_1(Player player, Monster[] enemy)
        {
            // 연속 공격: 최대 3명의 적에게 데미지 계수 * 1.0, 0.8, 0.6
            int temp = player.AttackPower;
            int numberOfEnemies = 0;
            for (int i = 0; i < enemy.Length; i++)
            {
                if (!enemy[i].IsDead)
                {
                    numberOfEnemies++;                                       //죽지 않은 적의 수
                }
            }

            ShowSituationNumber(player, enemy);
            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < Math.Min(3,numberOfEnemies); )            // i : 현재 몇번째 공격인지 나타냄 
                    {
                        player.AttackPower = (int)Math.Round(player.AttackPower * (1-0.2*i));   //공격 횟수가 많으면 위력 감소
                        if (enemy[sel - 1].IsDead)                               //대상이 죽은 상태면 공격 횟수를 늘리지 않고 다음 대상으로 넘어감
                        {
                            sel++;
                            continue;
                        }
                        player.Attack(enemy[sel - 1]);
                        player.AttackPower = temp;
                        i++;                                                    //공격 했다면 공격한 횟수를 늘려줌
                        sel++;
                    }
                }
            } while (repeat);

            player.AttackPower = temp;


        }

        public override void JobSkill_2(Player player, Monster[] enemy)
        {
            // 기절 마법: 1명의 적에게 데미지 계수 1.3, 기절 확률 33%
            // 33%확률로 기절시키는 코드가 추가되어야합니다.

            // if (isStunned)
            // {
            //     Console.WriteLine("적이 기절했습니다!");
            // }

            //캐릭터 클래스 변경 필요 
            int temp = player.AttackPower;
            player.AttackPower = (int)Math.Round(player.AttackPower * 1.3);
            ShowSituationNumber(player, enemy);

            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    repeat = true;
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    player.Attack(enemy[sel - 1]);
                    if(!enemy[sel - 1].IsDead)
                    {
                        if(new Random().Next(1,101)<=33)
                        {
                            Console.WriteLine($"기절 마법 성공 {enemy[sel-1].Name}이 기절했습니다.");
                            enemy[sel - 1].stun = 1;
                        }
                    }
                }
            } while (repeat);

            player.AttackPower = temp;

        }

        public override void JobSkill_3(Player player, Monster[] enemy)
        {
            // 즉사 마법: 체력이 33% 이하인 적을 즉사시킨다.

            ShowSituationNumber(player, enemy);

            Console.WriteLine("0.취소");
            
            bool repeat = false;
            do
            {
                int sel = Num.Sel(enemy.Length);
                repeat = false;
                if (sel == 0)
                {
                    player.stage.BattlePlayerTurn(player, enemy);
                }
                else if (enemy[sel - 1].IsDead)
                {
                    Console.WriteLine("이미 사망한 적입니다.");
                    repeat = true;
                }
                else
                {
                    if (enemy[sel - 1].Health > enemy[sel-1].Health *0.33)
                    {
                        Console.WriteLine("올바른 대상이 아닙니다.");
                        repeat = true;
                    }
                    else
                    {
                        enemy[sel - 1].Health = 0;
                        Console.WriteLine($"죽음 마법으로 {enemy[sel - 1].Name}이 죽었습니다.");
                    }
                    
                }
            } while (repeat);

        }

    }


}
