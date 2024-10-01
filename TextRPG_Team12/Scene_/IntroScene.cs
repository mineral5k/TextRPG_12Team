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
        // 콘솔의 가로 너비 가져오기
        int windowWidth = Console.WindowWidth;

        // 각 라인의 텍스트를 배열로 정의
        string[] asciiArt = new string[]
        {
            "⠀⠀⠀⠀⡀⡀⡀⡀⡀⠀⠀⠀⠀⠀⢀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⢠⣬⣿⠻⠻⢻⣧⣄⠀⠀⠀⠀⣽⣿⡯⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⠀⠀",
            "⠀⢸⣾⣯⠉⠀⠀⠉⢹⣷⣷⠀⠀⠀⢾⣿⡯⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⢹⣿⣯⠉⠉⠉⠉⠉⠁⠀⠀",
            "⠀⢸⣿⣿⠀⠀⠀⠀⢸⣿⣿⠀⠀⠀⣻⣿⡯⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠘⢟⣿⣄⣄⣄⣄⣽⡿⠏⠀⠀⠀⢾⣿⡯⠀ ⠰⠢⢖⣦⠂⠀⣢⡆⠀⢠⣠⣠⣠⡀⠀⣶⡐⣦⠀⠀⠀⠀⠀⠀⣄⣼⡿⠿⠿⣿⣄⠄⠀ ⠀⠀⠀⠀",
            "⠀⠀⢀⢀⢋⠋⠋⠋⠃⠀⠀⠀⠀⠀⠙⠙⠉⠀⠀⠀⠀⢐⣿⠀⠀⣺⡗⠎⠂⠀⠀⣿⠆⠀⣿⡸⣿⠀⠀⢐⣮⣶⣵⢿⡏⢃⢀ ⠉⣿⢷⣶⡕ ⠀",
            "⠀⠀⢘⣿⣿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣓⡚⠋⠀⠀⠚⠇⠀⠀⠀⠀⣿⠅⠀⣿⢞⣿⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⢘⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡆⠀⠀⠀⠀⠀⠀⠀⣀⣰⠟⠁⠀⣿⡪⣿⠀⢀⣀⣀⣀⣀⣀⣀⣸⣿⣿⣀⣀⣀⣀⣀⣀⣀⠀",
            "⠀⠀⠈⢛⣿⣵⣴⣦⣶⣴⣦⣶⣴⣦⣶⣴⡦⠀⠀⠀⠑⠙⠙⠙⠙⠙⠁⠀⠀⠈⠈⠀⠀⠀⠛⠈⠛⠀⠘⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠋"
        };

        foreach (string line in asciiArt)
        {
            int lineLength = line.Length;

            int padding = (windowWidth - lineLength) / 2;

            Console.WriteLine(new string(' ', padding) + line);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        // 닉네임 길이 정해두기
        Console.WriteLine("                                             \x1b[48;2;68;68;68m\x1b[38;2;255;255;255m▃ 사용하실 이름을 입력하세요 ▃\u001b[0m");
        Console.WriteLine();
        Console.Write("                                                         ");
        string name = Console.ReadLine();
        Console.WriteLine();

        //  1,2,3,4가 아닐 시 잘못된 입력입니다 출력하기??
        Console.WriteLine("\n                                             \x1b[48;2;68;68;68m\x1b[38;2;255;255;255m▃ 원하시는 직업을 선택하세요 ▃\u001b[0m");
        Console.WriteLine();
        Console.Write("\x1b[38;2;255;88;88m                                         1. \u001b[0m전사  ");
        Console.Write("\u001b[38;2;93;215;166m2. \u001b[0m궁수  ");
        Console.Write("\u001b[38;2;133;223;255m3. \u001b[0m도적  ");
        Console.WriteLine("\u001b[38;2;167;88;255m4. \u001b[0m마법사");
        Console.WriteLine();
        Console.Write("                                                           ");
        string inputJob = Console.ReadLine();
    }

        public IScene GetNextScene()
        {
            return new StartScene();
        }
    }
    
    
