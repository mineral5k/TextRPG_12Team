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
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Worrior()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }



        public void JobSkill_1()
        {

        }

        public void JobSkill_2()
        {

        }

        public void JobSkill_3()
        {

        }

    }

    public class Archer : Job
    {
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Archer()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }



        public void JobSkill_1()
        {

        }

        public void JobSkill_2()
        {

        }

        public void JobSkill_3()
        {

        }

    }

    public class Thief : Job
    {
        public string JobSkillName1 { get; set; }
        public string JobSkillName2 { get; set; }
        public string JobSkillName3 { get; set; }

        Thief()
        {
            JobHealth = 0;
            JobMana = 0;
            JobAttack = 0;
            JobDeffense = 0;
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }



        public void JobSkill_1()
        {

        }

        public void JobSkill_2()
        {

        }

        public void JobSkill_3()
        {

        }

        public class Mage : Job
        {
            public string JobSkillName1 { get; set; }
            public string JobSkillName2 { get; set; }
            public string JobSkillName3 { get; set; }

            Mage()
            {
                JobHealth = 0;
                JobMana = 0;
                JobAttack = 0;
                JobDeffense = 0;
                JobSkillName1 = "";
                JobSkillName2 = "";
                JobSkillName3 = "";
            }



            public void JobSkill_1()
            {

            }

            public void JobSkill_2()
            {

            }

            public void JobSkill_3()
            {

            }

        }






    }
}