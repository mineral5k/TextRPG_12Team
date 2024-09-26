namespace TextRPG_Team12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public abstract class Test
    {
        int a = 10;



        string Name { get; }

        int level { get; }
        int Health { get; set; }
        int AttackPower { get; set; }


        public void Bark()
        {


            Console.WriteLine(a);
        }

        public abstract void TakeDamage();
        
        

    }


    public class Monster : Test
    {


       
       
        public string Name { get; }
        public int level { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public override void TakeDamage()
        {



        }



    }


}
