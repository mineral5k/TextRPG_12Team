using System.Numerics;

namespace TextRPG_Team12
{
    public class StartScene
    {
        public static void startScene()
        {
            Console.WriteLine("스파르타 마을에 오신 것을 환영합니다.");
            Console.WriteLine("\n1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("0. 나가기");

            // 플레이어의 입력을 받음
            string input = Console.ReadLine();

            // 입력 값을 정수로 변환
        //    if (int.TryParse(input, out int choice))
        //    {
        //        switch (choice)
        //        {
        //            case 1:
        //                ShowStatus(); // 상태 보기 기능 호출
        //                break;
        //            case 2:
        //                Inventory(); // 인벤토리 기능 호출
        //                break;
        //            case 3:
        //                Shop(); // 상점 기능 호출
        //                break;
        //            case 0:
        //                ExitGame(); // 게임 종료 기능 호출
        //                break;
        //            default:
        //                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
        //                startScene(); // 잘못된 입력일 경우 다시 시작
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("숫자를 입력해주세요.");
        //        startScene(); // 유효하지 않은 입력일 경우 다시 시작
        //    }
        //}
            //    if (int.TryParse(input, out int choice))
            //    {
            //        switch (choice)
            //        {
            //            case 1:
            //                ShowStatus(); // 상태 보기 기능 호출
            //                break;
            //            case 2:
            //                Inventory(); // 인벤토리 기능 호출
            //                break;
            //            case 3:
            //                Shop(); // 상점 기능 호출
            //                break;
            //            case 4:
            //                Dungeon dungeon = new Dungeon();
            //                break;
            //            case 0:
            //                ExitGame(); // 게임 종료 기능 호출
            //                break;
            //            default:
            //                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
            //                startScene(); // 잘못된 입력일 경우 다시 시작
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("숫자를 입력해주세요.");
            //        startScene(); // 유효하지 않은 입력일 경우 다시 시작
            //    }
            //}

        //// 상태보기
        //public static void ShowStatus()
        //{
        //    // 플레이어 상태를 출력하는 코드
        //    Console.WriteLine("플레이어 상태를 출력합니다...");
        //    // 이후 startScene()으로 돌아가기
        //    startScene();
        //}
            //// 상태보기
            //public static void ShowStatus()
            //{
            //    // 플레이어 상태를 출력하는 코드
            //    Console.WriteLine("플레이어 상태를 출력합니다...");
            //    // 이후 startScene()으로 돌아가기
            //    startScene();
            //}

        //// 인벤토리
        //public static void Inventory()
        //{
        //    // 인벤토리 내용을 출력하고 관리하는 코드
        //    Console.WriteLine("인벤토리를 출력합니다...");
        //    // 이후 startScene()으로 돌아가기
        //    startScene();
        //}
            //// 인벤토리
            //public static void Inventory()
            //{
            //    // 인벤토리 내용을 출력하고 관리하는 코드
            //    Console.WriteLine("인벤토리를 출력합니다...");
            //    // 이후 startScene()으로 돌아가기
            //    startScene();
            //}

        //// 상점
        //public static void Shop()
        //{
        //    // 상점에서 아이템을 구매하는 코드
        //    Console.WriteLine("상점을 출력합니다...");
        //    // 이후 startScene()으로 돌아가기
        //    startScene();
        //}
            //// 상점
            //public static void Shop()
            //{
            //    // 상점에서 아이템을 구매하는 코드
            //    Console.WriteLine("상점을 출력합니다...");
            //    // 이후 startScene()으로 돌아가기
            //    startScene();
            //}

        //// 게임 종료
        //public static void ExitGame()
        //{
        //    Console.WriteLine("게임을 종료합니다.");
    }
            //// 게임 종료
            //public static void ExitGame()
            //{
            //    Console.WriteLine("게임을 종료합니다.");

            }
        }



    }
