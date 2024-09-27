namespace TextRPG_Team12
{
    internal class Program
    {
        private static Equipment[] EquipmentDb;

        static void Main(string[] args)
        {
            Player player;
            Console.WriteLine("사용하실 닉네임을 입력하세요.");
            string name = Console.ReadLine();

            Console.WriteLine("\n원하시는 직업을 선택하세요.");
            Console.WriteLine("1. 전사 2. 궁수 3. 도적 4. 마법사");


            bool repeat = false;
            // 번호 받아서 직업으로 배정  
            do
            {
                repeat = false;

                int choice = Num.Sel(4);
                switch (choice)
                {

                    case 0:
                        Console.WriteLine("잘못된 입력입니다");
                        repeat = true;
                        break;
                    case 1:
                        player = new Player(name, new Worrior());
                        break;
                    case 2:
                        player = new Player(name, new Archer());
                        break;
                    case 3:
                        player = new Player(name, new Thief());
                        break;
                    case 4:
                        player = new Player(name, new Mage());
                        break;
                }
            }
            while (repeat);
            StartScene.startScene();
        }


        //장비 정보
        static void EquipmentData()
        {
            EquipmentDb = new Equipment[]
            {
            new Equipment("훈련용 갑옷", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
            new Equipment("강철 갑옷", "강철로 제작된 튼튼한 갑옷입니다.", 9, 0, 2000, EquipmentType.Armor),
            new Equipment("멋쟁이 갑옷", "멋과 방어력 모두 챙긴 갑옷입니다.", 15, 0, 3500, EquipmentType.Armor),
            new Equipment("낡은 장검", "오래된 평범하고 낡은 검입니다.", 0, 2, 600, EquipmentType.Weapon),
            new Equipment("청동 손도끼", "고대 전사들이 사용하던 도끼입니다.", 0, 5, 1500, EquipmentType.Weapon),
            new Equipment("장군의 창", "전설 속 장군이 사용했다는 창입니다.", 0, 7, 2500, EquipmentType.Weapon)
            };
        }
    }

    static public class Num
    {
        static public int Sel(int x)                    // 0~x 까지의 선택지를 선택하는 메서드
        {
            int a = 0;

            Console.Write("원하시는 행동을 입력해 주세요 : ");

            while (true)
            {
                try                                 //숫자 이외의 입력을 받았을 시의 예외처리
                {
                    a = int.Parse(Console.ReadLine());
                }

                catch (System.FormatException)                 // 숫자이외의 입력을 받았을 시 오류 메세지를 전송하고 다시 입력을 받음
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                if ((0 <= a) && (a <= x))              //입력받은 숫자가 선택지에 올바른지 검사
                {
                    break;                        //올바를 시 종료
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다.");        // 선택지 범위에 맞지 않은 숫자 입력을 받았을 시 오류 메세지 전송하고 다시 입력 받음
                }

            }

            return a;                                //입력받은 값 반환

        }
    }



}
