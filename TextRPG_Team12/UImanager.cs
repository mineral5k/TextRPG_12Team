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
    }
}
