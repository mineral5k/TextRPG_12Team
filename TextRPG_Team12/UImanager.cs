using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    internal static class UImanager
    {
        public static void ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        } 

        public static void ReturnColor()
        {
            Console.ResetColor();
        }


        // 2개의 색상으로 텍스트 깜빡이는 연출
        public static void BlinkText(string text, int blinkCount, int interval, ConsoleColor color1, ConsoleColor color2)
        {
            // 현재 커서 위치를 저장
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            for (int i = 0; i < blinkCount; i++)
            {
                ChangeConsoleColor(color1);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);

                ChangeConsoleColor(color2);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);
            }

            ReturnColor();
        }

        // 4개의 색상으로 텍스트 깜빡이는 연출
        public static void BlinkText2(string text, int blinkCount, int interval, ConsoleColor color1, ConsoleColor color2, ConsoleColor color3, ConsoleColor color4)
        {
            // 현재 커서 위치를 저장
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            for (int i = 0; i < blinkCount; i++)
            {
                ChangeConsoleColor(color1);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);

                ChangeConsoleColor(color2);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);

                ChangeConsoleColor(color3);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);

                ChangeConsoleColor(color4);
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write(text);
                Thread.Sleep(interval);
            }

            ReturnColor();
        }
        public static void EndingAnimation()
        {
            // 1
            string asciiArt1 = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢾⢳⡀⠀⠀⢠⣶⣶⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⢷⣳⡀⠀⠘⢿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢙⣿⣖⣴⢞⡟⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠻⠟⠹⡅⢐⡇⠀⠙⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢐⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⡞⠹⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⡃⠀⠹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

            // 2
            string asciiArt2 = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣫⠏⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣯⠏⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⣾⢯⠀⢀⣴⣦⣄⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⠛⠻⣦⣼⣿⣿⡗⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⢀⣠⡴⠚⢁⡟⠀⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠴⠖⠛⢉⡽⠃⠀⠀⠸⠅⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⡾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";

            // 3
            string asciiArt3 = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠶⣶⡄⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣆⣠⣾⠷⠋⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣩⣿⣯⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠒⠶⠶⢤⣄⡀⣀⣁⣙⢶⣤⣾⣷⣦⠀⠀
⠀⠀⠀⠀⠀⠀⣠⡴⠞⠋⠉⠈⢈⡽⠋⠿⠿⠏⠀⠀
⠀⠀⠀⠀⠐⠋⠁⠀⠀⠀⠀⠰⠏⠀⠀⠀⠀⠀⠀⠀";

            // GameOver
            string finalText = @"
⠀⣀⣀⡀⠀⠀⣀⡀⠀⢀⡀⠀⠀⢀⡀⢀⣀⣀⡀⠀⠀⠀⣀⣀⠀⢀⡀⠀⢀⡀⢀⣀⣀⡀⠀⣀⣀⡀⠀⠀
⣾⠋⣉⡁⠀⢰⠟⣧⠀⢸⣷⡀⢰⣿⡂⢽⣋⣉⡀⠀⠀⢽⡉⠙⢷⡀⣿⠀⢸⡇⢸⣏⣉⡁⢸⡏⠉⣿⠀⠀
⣿⡀⠉⣿⢀⡿⠤⢽⡆⢸⡏⢾⡏⢺⡅⢽⡋⠉⠀⠀⠀⢽⡂⢀⣻⡀⢹⣆⡿⠀⢸⡏⠉⠁⢸⡏⠹⣏⠀⠀
⠈⠉⠉⠁⠈⠁⠀⠀⠉⠈⠁⠀⠀⠉⠀⠉⠉⠉⠁⠀⠀⠈⠉⠉⠁⠀⠀⠉⠁⠀⠈⠉⠉⠁⠈⠁⠀⠉⠀⠀";

            // 콘솔 창의 크기
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            string[] asciiArts = { asciiArt1, asciiArt2, asciiArt3 };

            // 3컷 애니메이션
            for (int i = 0; i < 3; i++)
            {
                string currentArt = asciiArts[i];

                // 아스키 아트의 가로/세로 크기 계산
                string[] artLines = currentArt.Split('\n');
                int artWidth = artLines[0].Length;
                int artHeight = artLines.Length;

                // 중앙에 출력할 위치 계산
                int startX = (consoleWidth - artWidth) / 2 - 10;
                int startY = (consoleHeight - artHeight) / 2;

                // 커서를 중앙으로 이동하고 출력
                Console.Clear();
                Console.SetCursorPosition(startX, startY);

                foreach (string line in artLines)
                {
                    Console.SetCursorPosition(startX, Console.CursorTop); // 가로 중앙 맞춤
                    Console.WriteLine(line);
                }

                Thread.Sleep(500);
            }

            // GameOver 깜빡임
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();

                // 색상 변경
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                // 중앙에 출력할 위치 계산
                string[] finalTextLines = finalText.Split('\n');
                int finalTextWidth = finalTextLines[0].Length;
                int finalTextHeight = finalTextLines.Length;
                int finalStartX = (consoleWidth - finalTextWidth) / 2 - 18;
                int finalStartY = (consoleHeight - finalTextHeight) / 2;

                // 텍스트 출력
                Console.SetCursorPosition(finalStartX, finalStartY);
                foreach (string line in finalTextLines)
                {
                    Console.SetCursorPosition(finalStartX, Console.CursorTop);
                    Console.WriteLine(line);
                }

                Thread.Sleep(300);
            }

            Console.ResetColor();
        }
    }
}
