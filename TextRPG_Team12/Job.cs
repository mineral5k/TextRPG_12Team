using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            JobSkillName1 = "";
            JobSkillDesc1 = "";
            JobSkillName2 = "";
            JobSkillDesc2 = "";
            JobSkillName3 = "";
            JobSkillDesc3 = "";

        }



        public override void JobSkill_1()
        {

        }

        public override void JobSkill_2()
        {

        }

        public override void JobSkill_3()
        {

        }

    }

    public class Archer : Job
    {


        public Archer()
        {
            JobName = "궁수";
            JobHealth = 0;
            JobMana = 0;
            JobAttackPower = 0;
            JobAmorDeffense = 0;
            JobSkillName1 = " ";
            JobSkillName2 = " ";
            JobSkillName3 = " ";
        }



        public override void JobSkill_1()
        {

        }

        public override void JobSkill_2()
        {

        }

        public override void JobSkill_3()
        {

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
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }



        public override void JobSkill_1()
        {

        }

        public override void JobSkill_2()
        {

        }

        public override void JobSkill_3()
        {

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
            JobSkillName1 = "";
            JobSkillName2 = "";
            JobSkillName3 = "";
        }



        public override void JobSkill_1()
        {

        }

        public override void JobSkill_2()
        {

        }

        public override void JobSkill_3()
        {

        }

    }


}
