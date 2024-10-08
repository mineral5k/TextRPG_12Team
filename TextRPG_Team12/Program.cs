﻿using SixLabors.Fonts.Unicode;
using static TextRPG_Team12.Quest;

namespace TextRPG_Team12
{
    internal class Program
    {
        
        public static List<Equipment> EquipmentDb;
        public static string name;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IScene currentScene = new IntroScene();
            SaveLoad saveload = new SaveLoad();
            Player player = new Player("def", null);
            saveload.LoadData(ref player, ref player.job, currentScene);
            currentScene = currentScene.GetNextScene();          
            Console.Clear();


            while (true)
            {
                saveload.SaveData(player, player.job);
                Console.Clear();
                currentScene.OnShow();
               int sel = Num.Sel(7);
                switch (sel)
                {
                    case 1:
                        ShowStatus(player); // 상태 보기 기능 호출
                        break;
                    case 2:
                        Inventory(player); // 인벤토리 기능 호출
                        break;
                    case 3:
                        Shop(player); // 상점 기능 호출
                        break;
                    case 4:
                        player.stage.Dungeon(player);
                        break;
                    case 5:
                        ShowQuest(player);
                        break;
                    case 6:
                        Inn(player);
                        break;
                    case 7:
                        Change(player);
                        break;
                    case 0:
                        ExitGame(player); // 게임 종료 기능 호출
                        break;
                }
            }
        }


        //장비 정보
        static void EquipmentData()
        {
            EquipmentDb = new List<Equipment>
            {
            new Equipment("훈련용 갑옷", "천으로 만들어져 가벼운 훈련복입니다.", 5, 0, 1000, EquipmentType.Armor),
            new Equipment("강철 갑옷", "강철로 제작된 튼튼한 갑옷입니다.", 9, 0, 2000, EquipmentType.Armor),
            new Equipment("멋쟁이 갑옷", "멋과 방어력 모두 챙긴 갑옷입니다.", 15, 0, 3500, EquipmentType.Armor),
            new Equipment("고블린의 목걸이", "고블린들이 애타게 찾고 있는 목걸이입니다. 작은 힘이 깃들어 있습니다.", 0, 2, 600, EquipmentType.Weapon),
            new Equipment("트롤의 반지", "트롤의 힘을 담은 반지로, 착용한 자에게 강력한 힘을 부여합니다.", 0, 5, 1500, EquipmentType.Weapon),
            new Equipment("드래곤의 이빨", "드래곤의 이빨로 만들어진 무기로, 소지 시 드래곤의 기운이 전해집니다.", 0, 7, 2500, EquipmentType.Weapon),
            };           
        }

        // 상태보기
        public static void ShowStatus(Player player)
        {
            Console.Clear();
            // 플레이어 상태를 출력하는 코드
            Console.WriteLine("플레이어 상태를 출력합니다...");

            player.ShowStatus();
            Num.Sel(0);
        }


        // 인벤토리
        public static void Inventory(Player player)
        {    
            Console.Clear();
            // 인벤토리 내용을 출력하고 관리하는 코드
            Console.WriteLine("인벤토리를 출력합니다...");
            player.ShowInventory(false, false);
            if (Num.Sel(1) == 1)
            {

         
               int item = Num.Sel(player.ShowInventory(true, true)) - 1;
                player.EquipItem(item);


            }
        }


        // 상점
        public static void Shop(Player player)
        {
            // 상점에서 아이템을 구매하는 코드
            Console.WriteLine("상점을 출력합니다...");

            player.ShowShop(false);


            int buySell = Num.Sel(2);


            if (buySell == 1)
            {
                int shopList = Num.Sel(player.ShowShop(true)) - 1;
                player.BuyShop(shopList,player);


            }
            else if (buySell == 2)
            {
                int InventoryList = Num.Sel(player.ShowInventory(true, false)) - 1;
                player.SellShop(InventoryList);

            }
        }

        // 퀘스트
        public static void ShowQuest(Player player)
        {
            Console.Clear();
            Console.WriteLine();

          
            Player.QuestMenu(player);
        }


        // 게임 종료
        public static void ExitGame(Player player)
        {
            Console.WriteLine("게임을 종료합니다.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        public static void Inn (Player player)
        {
            Console.Clear();
            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine("700G 를 지불하여 체력과 마나를 모두 회복합니다.");
            Console.Write("\u001b[0m");
            Console.Write("현재 소지 골드 :");
            Console.Write("\u001b[38;2;255;255;210m ");
            Console.Write($"[{player.Gold}]");
            Console.WriteLine("\u001b[0m");
            Console.WriteLine($"\n1. 휴식한다.");
            Console.Write($"\u001b[38;2;255;150;150m");
            Console.WriteLine("0. 돌아간다");
            Console.Write("\u001b[0m");

            int sel = Num.Sel(1);

            if (sel ==0)
            {

            }

            else if (sel ==1)
            {
                if (player.Gold<700)
                {
                    Console.Write("\u001b[38;2;255;88;88m");
                    Console.WriteLine("보유 Gold가 부족합니다. 마을로 돌아갑니다.");

                    Console.Write("\u001b[0m");
                    Console.Write("\u001b[38;2;255;150;150m");
                    Console.WriteLine(" 0. 돌아간다");
                    Console.Write("\u001b[0m");
                    Num.Sel(1);
                }
                else
                {
                    Console.WriteLine("");
                    UImanager.BlinkText2("체력과 마나가 모두 회복되었습니다.", 3, 100, ConsoleColor.Blue, ConsoleColor.DarkCyan, ConsoleColor.Cyan, ConsoleColor.DarkBlue);
                    Console.Write("\u001b[0m");
                    player.Health = player.MaxHealth;
                    player.Mana = player.MaxMana;
                    player.Gold -= 700;
                    Console.WriteLine();
                    Console.WriteLine("0. 확인");
                    Num.Sel(0);
                }
            }


        }

        public static void Change(Player player)
        {
            Console.Clear();
            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine("선택한 직업으로 직업을 변경합니다.");
            Console.Write("\u001b[0m");
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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("4. ");
            Console.ResetColor();
            Console.WriteLine("마법사");
            Console.Write("\u001b[38;2;255;150;150m");
            Console.WriteLine();
            Console.WriteLine("0. 돌아간다");
            Console.Write("\u001b[0m");

            int sel = Num.Sel(4);
            {
                switch(sel)
                {
                    case 0:
                        break;
                    case 1:
                        player.job = new Worrior();
                        break;
                    case 2:
                        player.job = new Archer();
                        break;
                    case 3:
                        player.job = new Thief();
                        break;
                    case 4:
                        player.job = new Mage();
                        break;
                }
                
                player.MaxHealth = 100 + player.job.JobHealth;
                player.MaxMana = 50 + player.job.JobMana;
                if(player.Health >player.MaxHealth)
                {
                    player.Health = player.MaxHealth;
                }
                if (player.Mana > player.MaxMana)
                {
                    player.Mana = player.MaxMana;
                }
                player.AttackPower = 10 + player.job.JobAttackPower + player.Level-1;
                player.AmorDefense = 5 + player.job.JobAmorDeffense + player.Level-1;
            }
        }
    }
}

    
static public class Num
{
        static public int Sel(int x)                    // 0~x 까지의 선택지를 선택하는 메서드
        {
            int a = 0;
            Console.Write(">> ");
            while (true)
            {
                try                                 //숫자 이외의 입력을 받았을 시의 예외처리
                {
                    a = int.Parse(Console.ReadLine());
                 }
                catch (System.FormatException)                 // 숫자이외의 입력을 받았을 시 오류 메세지를 전송하고 다시 입력을 받음
                {
                    Console.Write("\u001b[38;2;255;150;150m");
                    Console.WriteLine("잘못된 입력입니다.\u001b[0m");
                    continue;
                }
                if ((0 <= a) && (a <= x))              //입력받은 숫자가 선택지에 올바른지 검사
                {
                    break;                        //올바를 시 종료
                }
                else
                {
                    Console.Write("\u001b[38;2;255;150;150m");
                    Console.WriteLine("잘못된 입력입니다.\u001b[0m");        // 선택지 범위에 맞지 않은 숫자 입력을 받았을 시 오류 메세지 전송하고 다시 입력 받음
                }
            }
            return a;                                //입력받은 값 반환
        }
}



