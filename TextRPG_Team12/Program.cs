namespace TextRPG_Team12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("사용하실 닉네임을 입력하세요.");
            string name = Console.ReadLine();

            Console.WriteLine("\n원하시는 직업을 선택하세요.");
            Console.WriteLine("1. 전사 2. 궁수 3. 도적 4. 마법사");

       
            // int jobChoice = GetInput();

            // 번호 받아서 직업으로 배정  
            string job = Console.ReadLine();

            Console.WriteLine();
            StartScene.startScene();
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
