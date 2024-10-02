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
// 튜터님께 질문하고 답변받은 부분인데, 사용하지 않으면 이후에 삭제하겠습니다!