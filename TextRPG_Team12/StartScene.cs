using System.Numerics;
using TextRPG_Team12;

namespace TextRPG_Team12
{
    public class StartScene : IScene
    {
        IScene nextScene = null;
        public string Name { get; set; }
        public void OnShow()
        {
            Console.WriteLine("스파르타 마을에 오신 것을 환영합니다.");
            Console.WriteLine("\n1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("5. 퀘스트 확인");
            Console.WriteLine("6. 휴식하기");
            Console.WriteLine("7. 직업 변경");

            Console.WriteLine("0. 나가기");

           
        }

        public IScene GetNextScene()
        {
            return nextScene;
        }
    }
}