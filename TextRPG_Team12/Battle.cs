using System;
namespace TextRPG_Team12
{
	public class Battle
    {

        //플레이어와 적의 체력 및 공격력
        private int playerHealth { get; set; }
        private int enemyHealth { get; set; }
        private int playerAttackDamage { get; set; }
        private int enemyAttackDamage { get; set; }
        private int stage = 1;

        // 적 기본 체력 및 공격력 (첫 스테이지 기준)
        private int baseEnemyHealth = 80;
        private int baseEnemyAttackDamage = 15;
        private Player player;
        private Monster enemy;

        public Battle(Player player, Monster enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine($"{enemy.Name}이(가) 나타났습니다! 무엇을 하시겠습니까?");

            // 턴제 전투가 끝날 때까지 반복
            while (!player.IsDead && !enemy.IsDead)
            {
                Console.WriteLine("\n1. 공격하기");
                Console.WriteLine("2. 스킬 사용하기 (추후 구현)");
                Console.WriteLine("3. 도망치기");

                int choice = Num.Sel(3, player, enemy);

                if (choice == -1) // 도망치기 선택 시
                {
                    Console.WriteLine($"{player.Name}이(가) 도망쳤습니다. 전투 종료.");
                    break;
                }

                // 전투 종료 체크
                if (player.IsDead)
                {
                    Console.WriteLine($"{player.Name}이(가) 사망했습니다. 게임 오버.");
                    break;
                }
                else if (enemy.IsDead)
                {
                    Console.WriteLine($"{enemy.Name}을(를) 물리쳤습니다!");
                    break;
                }
            }
        }
    }
}

