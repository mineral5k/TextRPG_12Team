using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team12;

internal class IntroScene : IScene
    {
        public string Name { get; }
        public void OnShow()
        {
        Console.WriteLine("사용하실 닉네임을 입력하세요.");
        string name = Console.ReadLine();

        Console.WriteLine("\n원하시는 직업을 선택하세요.");
        Console.WriteLine("1. 전사 2. 궁수 3. 도적 4. 마법사");
        string inputJob = Console.ReadLine();
    }

        public IScene GetNextScene()
        {
            return new StartScene();
        }
    }
    
    
