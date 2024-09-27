using System;
namespace TextRPG_Team12
{
	public class Dungeon
	{
        // 플레이어와 적의 체력 및 공격력
        private int playerHealth { get;  set; }
        private int enemyHealth { get;  set; }
        private int playerAttackDamage { get;  set; }
        private int enemyAttackDamage { get;  set; }
        private int stage = 1;

        // 적 기본 체력 및 공격력 (첫 스테이지 기준)
        private int baseEnemyHealth = 80;
        private int baseEnemyAttackDamage = 15;

        public Dungeon()
        {
            Console.WriteLine("던전에 입장했습니다. 전투를 준비하세요");
            //Enter();
        }

        // 적의 체력과 공격력을 설정하는 함수 (스테이지에 따라 증가)
        public void SetupEnemy()
        {
            enemyHealth = (int)(baseEnemyHealth * Math.Pow(1.15, stage - 1));  // 15% 증가
            enemyAttackDamage = (int)(baseEnemyAttackDamage * Math.Pow(1.15, stage - 1));  // 15% 증가
            Console.WriteLine($"[스테이지 {stage}] 적의 체력: {enemyHealth}, 공격력: {enemyAttackDamage}");
        }

        //// 전투 상황
        public void Enter()
        {
            Console.WriteLine("적이 나타났습니다! 무엇을 하시겠습니까?");

            // 턴제 전투가 끝날 때까지 반복
            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("\n1. 공격하기");
                Console.WriteLine("2. 스킬 사용하기");
                Console.WriteLine("3. 도망치기");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            PlayerAttack();  // 플레이어가 공격
                            if (enemyHealth > 0)
                            {
                                EnemyAttack();  // 적이 반격
                            }
                            break;

                        case 2:
                            UseSkill();  // 스킬 사용
                            if (enemyHealth > 0)
                            {
                                EnemyAttack();  // 적이 반격
                            }
                            break;

                        case 3:
                            RunAway();  // 도망치기
                            return; //  함수 종료
                        default:
                            Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }

                // 전투 종료 체크
                if (playerHealth <= 0)
                {
                    Console.WriteLine("플레이어가 사망했습니다. 게임 오버.");
                    break;
                }
                else if (enemyHealth <= 0)
                {
                    Victory();  // 승리 시 보상 및 선택지
                    break;
                }
            }
        }

        //// 플레이어 공격
        public void PlayerAttack()
        {
            Console.WriteLine($"플레이어가 적을 공격했습니다! 적에게 {playerAttackDamage}의 피해를 입혔습니다.");
            enemyHealth -= playerAttackDamage;
            Console.WriteLine($"적의 남은 체력: {enemyHealth}");
        }

        //// 적 공격
        public void EnemyAttack()
        {
            Console.WriteLine($"적이 반격했습니다! 플레이어는 {enemyAttackDamage}의 피해를 입었습니다.");
            playerHealth -= enemyAttackDamage;
            Console.WriteLine($"플레이어의 남은 체력: {playerHealth}");
        }

        //// 도망치기 기능
        public void RunAway()
        {
            Console.WriteLine("도망쳤습니다! 던전에서 빠져나갑니다.");
        }

        //// 전투 승리 시
        public void Victory()
        {
            Console.WriteLine("적을 물리쳤습니다! 승리했습니다.");

            // 보상 정하기
            playerGold += 50;  // 50 골드 보상
            playerHealth += 30;  // 30 체력 회복 (최대 100을 넘지 않도록)
            if (playerHealth > 100) playerHealth = 100;

            Console.WriteLine($"보상으로 50 골드를 얻었습니다! 현재 골드: {playerGold}");
            Console.WriteLine($"보상으로 30 체력을 회복했습니다! 현재 체력: {playerHealth}");

            // 다음 선택
            Console.WriteLine("\n1. 다음 스테이지로 진행");
            Console.WriteLine("2. 게임 종료");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        NextStage();  // 다음 스테이지로 진행
                        break;
                    case 2:
                        EndGame();  // 게임 종료
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
                        Victory();  // 잘못된 선택 시 다시 선택
                        break;
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Victory();  // 잘못된 입력 시 다시 선택
            }
        }

        // 다음 스테이지 진행
        public void NextStage()
        {
            Console.WriteLine("다음 스테이지로 이동합니다.");
            stage++;  // 스테이지 증가
            SetupEnemy();  // 새로운 적의 체력과 공격력을 설정
            Enter();  // 새로운 적과 다시 전투 시작
        }

        // 게임 종료
        public void EndGame()
        {
            Console.WriteLine("던전을 떠났습니다.");
            StartScene.startScene();
        }
    }
}

