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



        public virtual void JobSkill_1()
        {

        }

        public virtual void JobSkill_2()
        {

        }

        public virtual void JobSkill_3()
        {

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
            JobSkillName3 = "반사";
            JobSkillDesc3 = "적의 공격을 1회 되돌려줍니다.";

        }



        public override void JobSkill_1()
        {
            // 파워 어택: 한 명의 적에게 공격력의 1.5배 공격
            // 공격 대상 선택 구현 ?
            int damage = (int)(JobAttackPower * 1.5);
            Console.WriteLine($"{JobSkillName1}! 적에게 {damage}의 데미지를 입혔습니다! ");
        }

        public override void JobSkill_2()
        {
            // 파워 슬래시: 전체 적들에게 공격력의 0.8배 공격
            // 전체 공격
            int damage = (int)(JobAttackPower * 0.8);
            Console.WriteLine($"{JobSkillName2}! 적들에게 {damage}의 데미지를 입혔습니다!");
        }

        public override void JobSkill_3()
        {
            // 반사: 적의 공격을 1회 되돌린다.
            // 데미지 무시 및 전달 혹은 데미지 피격과 전달
            Console.WriteLine($"{JobSkillName3}! 적의 다음 공격을 되돌려줍니다.");
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
            JobSkillDesc2 = "한 명의 적에게 3턴 동안 지속되는 상처를 남깁니다. 상처는 공격력의 33%에 해당하는 데미지를 줍니다.";
            JobSkillName3 = "화살비";
            JobSkillDesc3 = "모든 적에게 화살을 퍼붓습니다. 화살의 데미지는 생존 중인 적의 수에 따라 달라집니다.";
        }



        public override void JobSkill_1()
        {
            // 속사 : 한 명의 적에게 공격력의 0.5배로 3회 공격
            // 공격 대상 선택 구현 ?
            // 타수마다 치명타가 존재하면 ?
            // 데미지를 최종 데미지 표기 방식
            int damage = (int)(JobAttackPower * 0.5);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}: {damage}!");
            }
            Console.WriteLine($"{JobSkillName1}! 적에게 {damage}의 데미지를 입혔습니다! ");
        }

        public override void JobSkill_2()
        {
            // 독화살: 한 명의 적에게 3턴 동안 지속되는 상처를 남깁니다.
            // 공격 대상 선택 구현 ?
            int damage = (int)(JobAttackPower * 0.33); // 공격력의 1/3

            //턴 개념이 필요합니다 .
            poisonTurns = 3; // 3턴 동안 지속
            Console.WriteLine($"{JobSkillName2}! 적이 3턴 동안 {damage}의 데미지를 받습니다!");
        }

        public override void JobSkill_3()
        {
            // 화살비: 모든 적에게 화살을 퍼붓습니다.
            // 전체 공격 
            int numberOfEnemies = 0; // 적의 수 정보를 받아와야합니다.
            int damage = (int)(JobAttackPower * 2.5 / numberOfEnemies);
            Console.WriteLine($"{JobSkillName3}! {numberOfEnemies}명의 적에게 {damage}의 데미지를 입혔습니다!");
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
            JobSkillDesc2 = "적의 다음 공격을 100%로 회피합니다.";
            JobSkillName3 = "흡혈";
            JobSkillDesc3 = "적에게 공격력의 110%의 피해를 주고 데미지의 50%에 해당하는 체력을 흡수합니다.";
        }



        public override void JobSkill_1()
        {

            // 타수 마다 치명타 적용 ?
            // 최종 데미지 표기 확인 부탁드립니다 .
            int damage = (int)(JobAttackPower * 1.6);
            Console.WriteLine($"{JobSkillName1}! 적에게 {damage * 0.8}의 데미지를 2번 입혔습니다! ");

        }

        public override void JobSkill_2()
        {
            // 은신: 적의 다음 공격을 100% 회피
            // 회피율 변수가 적용되면 구현 부탁드립니다 .
            Console.WriteLine($"{JobSkillName2}! 다음 적의 공격을 회피합니다!");
           
        }

        public override void JobSkill_3()
        {
            // 흡혈: 적에게 공격력의 110% 피해를 주고 체력 회복
            int damage = (int)(JobAttackPower * 1.1);
            int healthRestored = (int)(damage * 0.5);
            JobHealth += healthRestored;
            Console.WriteLine($"{JobSkillName3}! 적에게 {damage}의 데미지를 주고 {healthRestored}의 체력을 훔쳤습니다!");
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
            JobSkillDesc3 = "체력이 50% 이하인 적을 즉사시킨다.";
        }



        public override void JobSkill_1()
        {
            // 연속 공격: 최대 3명의 적에게 데미지 계수 * 1.0, 0.8, 0.6
           
        }

        public override void JobSkill_2()
        {
            // 기절 마법: 1명의 적에게 데미지 계수 1.3, 기절 확률 33%
            int damage = (int)(JobAttackPower * 1.3);

            // 33%확률로 기절시키는 코드가 추가되어야합니다.
            Console.WriteLine($"{JobSkillName2}! 적에게 {damage}의 데미지를 입혔습니다.");
            if (isStunned)
            {
                Console.WriteLine("적이 기절했습니다!");
            }
            
        }

        public override void JobSkill_3()
        {
            // 즉사 마법: 체력이 50% 이하인 적을 즉사시킨다.
        }

    }


}
