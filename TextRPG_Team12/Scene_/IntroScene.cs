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
        Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
        Console.WriteLine("• 사용하실 이름을 입력하세요 \u001b[0m");
        Name = Console.ReadLine();
        Console.Write("\n\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
        Console.WriteLine("• 원하시는 직업을 선택하세요 \u001b[0m");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("1. ");
        Console.ResetColor();
        Console.Write("전사  ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("2. ");
        Console.ResetColor();
        Console.Write("궁수  ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("3. ");
        Console.ResetColor();
        Console.Write("도적  ");
        Console.ForegroundColor= ConsoleColor.DarkMagenta;
        Console.Write("4. ");
        Console.ResetColor();
        Console.WriteLine("마법사");


    }

    public IScene GetNextScene()
        {
            return new StartScene();
        }
    }
    
    
