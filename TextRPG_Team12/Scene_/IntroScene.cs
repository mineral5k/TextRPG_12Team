using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team12;

public class IntroScene : IScene
    {
        public string Name { get; set; }
        public void OnShow()
        {
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("⠀⢠⣾⠚⣶⡄⠀⠀⣷⡂⠀⢀⣤⣤⣤⣤⣤⣤⣤⡄⠀");
        Console.WriteLine("⠀⣿⡂⠀⢐⣿⠀⠀⣿⡂⠀⠀⠀⠀⠀⣿⡂⠀⠀⠀⠀");
        Console.WriteLine("⠀⠈⠻⠶⠯⠁⠀⠀⠿⠂⠀⢀⣀⣰⡾⠉⠽⣆⣀⡀⠀");
        Console.WriteLine("⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡂⠀⠀⠀⠀");
        Console.WriteLine("⠀⠘⢿⢤⢤⡤⡤⣤⢤⠀⠀⠓⠓⠓⠓⠛⠓⠓⠓⠓⠀");
        Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine();
        Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine();
        Console.WriteLine("\x1b[48;2;30;30;30m\x1b[38;2;255;255;255m• 사용하실 이름을 입력하세요 \u001b[0m");
        Name = Console.ReadLine();
        Console.WriteLine("\n\x1b[48;2;30;30;30m\x1b[38;2;255;255;255m• 원하시는 직업을 선택하세요 \u001b[0m");
        Console.WriteLine("\x1b[38;2;255;88;88m1. \u001b[0m전사  \u001b[38;2;93;215;166m2. \u001b[0m궁수  \u001b[38;2;133;223;255m3. \u001b[0m도적  \u001b[38;2;167;88;255m4. \u001b[0m마법사");
    }

    public IScene GetNextScene()
        {
            return new StartScene();
        }
    }
    
    
