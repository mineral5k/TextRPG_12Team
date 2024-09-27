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
