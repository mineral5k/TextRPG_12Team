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
    }
}