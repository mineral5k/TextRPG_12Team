using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    public class Job
    {
        public int JobHealth { get; set; }
        public int JobMana { get; set; }
        public int JobAttack { get; set; }
        public int JobDeffense { get; set; }
        public int JobDefense { get; set; }
        //치명타 스크립트에서 받아오기
        public int JobCritical { get; set; }
        //회피 스크립트에서 받아오기
        public int JobEvasion { get; set; }

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
    public class Warrior : Job
    {
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Worrior()
        public Warrior()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }

            JobDefense = 0;
            JobCritical = 0;
            JobEvasion = 0;

            JobSkillName1 = "찌르기"; // 단일기 스킬 이름 수정바람
            JobSkillName2 = "휘두르기"; // 다중기 스킬 이름 수정바람
            JobSkillName3 = "웅크리기"; // 방어력을 올리는 버프 이름 수정바람 
        }

        public void JobSkill_1()
        public override void JobSkill_1()
        {

            int damage = (int)(JobAttack * 1.2); 
            Console.WriteLine($"{JobSkillName1}: 적에게 {damage}의 피해를 입혔습니다.");
        }

        public void JobSkill_2()
      
        public override void JobSkill_2()
        {

            int damage = (int)(JobAttack * 0.8); 
            Console.WriteLine($"{JobSkillName2}: 여러 적에게 각각 {damage}의 피해를 입혔습니다.");
        }

        public void JobSkill_3()
        public override void JobSkill_3()
        {
            int buffAmount = 10; 
            JobDefense += buffAmount;
            Console.WriteLine($"{JobSkillName3}: 방어력이 {buffAmount}만큼 상승하여 현재 방어력은 {JobDefense}입니다.");
        }

    }

    public class Archer : Job
    {
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Archer()
        public Archer()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }

            JobDefense = 0;
            JobCritical = 0;
            JobEvasion = 0;

            JobSkillName1 = "크리티컬 샷"; // 단일기 
            JobSkillName2 = "레인 애로우"; // 다수기 
            JobSkillName3 = "포커스";     // 치명타 향상 버프
        }

        public void JobSkill_1()
        public override void JobSkill_1()
        {

            int damage = (int)(JobAttack * 1.4);
            Console.WriteLine($"{JobSkillName1}: 적에게 {damage}의 치명상을 입혔습니다.");
        }

        public void JobSkill_2()
        public override void JobSkill_2()
        {
            int damage = (int)(JobAttack * 0.8);
            Console.WriteLine($"{JobSkillName2}: 여러 적에게 각각 {damage}의 피해를 입혔습니다.");
        }

        public void JobSkill_3()
        public override void JobSkill_3()
        {

            int buffAmount = 0;
            JobCritical *= buffAmount;
            Console.WriteLine($"{JobSkillName3}: 치명타율이 {buffAmount}배 만큼 상승하여 현재 치명타율은 {JobCritical}입니다.");
        }

    }

    public class Thief : Job
    {
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Thief()
        public Thief()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }

            JobDefense = 0;
            JobCritical = 0;
            JobEvasion = 0;

            JobSkillName1 = "표창 던지기";  // 단일기 
            JobSkillName2 = "표창 난사";   // 다수기 
            JobSkillName3 = "축지법";     // 회피율 버프 
        }

        public void JobSkill_1()
        public override void JobSkill_1()
        {
            int damage = (int)(JobAttack * 1.3);
            Console.WriteLine($"{JobSkillName1}: 적에게 {damage}의 피해를 입혔습니다.");
        }

        public void JobSkill_2()
        public override void JobSkill_2()
        {

            int damage = (int)(JobAttack * 0.9);
            Console.WriteLine($"{JobSkillName2}: 여러 적에게 각각 {damage}의 피해를 입혔습니다.");
        }

        public void JobSkill_3()
        public override void JobSkill_3()
        {
            int buffAmount = 0;
            JobEvasion *= buffAmount;
            Console.WriteLine($"{JobSkillName3}: 회피율이 {buffAmount}배 만큼 상승하여 현재 회피율은 {JobEvasion}입니다.");
        }

        public class Mage : Job
        {
            public string JobSkillName1 { get; set; }
            public string JobSkillName2 { get; set; }
            public string JobSkillName3 { get; set; }

            Mage()
            public Mage()
            {
                JobHealth = 0;
                JobMana = 0;
                JobAttack = 0;
                JobDeffense = 0;
                JobSkillName1 = "";
                JobSkillName2 = "";
                JobSkillName3 = "";
                JobDefense = 0;
                JobCritical = 0;
                JobEvasion = 0;

                JobSkillName1 = "에너지 볼트"; // 단일기 
                JobSkillName2 = "썬더 볼트";  // 다수기 
                JobSkillName3 = "현자타임";  // 공격력 상승 버프
            }



            public void JobSkill_1()
            public override void JobSkill_1()
            {

                int damage = (int)(JobAttack * 1.3);
                Console.WriteLine($"{JobSkillName1}: 적에게 {damage}의 피해를 입혔습니다.");
            }

            public void JobSkill_2()
            public override void JobSkill_2()
            {
                int damage = (int)(JobAttack * 0.9);
                Console.WriteLine($"{JobSkillName2}: 여러 적에게 각각 {damage}의 피해를 입혔습니다.");
            }

            public void JobSkill_3()
            public override void JobSkill_3()
            {

                int buffAmount = 0;
                JobAttack += buffAmount;
                Console.WriteLine($"{JobSkillName3}: 공격력이 {buffAmount}만큼 상승하여 현재 공격력은 {JobAttack}입니다.");
            }

        }


       




    }
}