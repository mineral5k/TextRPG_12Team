using System;

namespace TextRPG_Team12
{
    public abstract class Quest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; protected set; }
        public int CompletionCount { get; private set; } 

        public Quest(string name)
        {
            Name = name;
            IsCompleted = false;
            CompletionCount = 0; 
        }

        public abstract void CheckProgress();

        // 퀘스트 완료 메서드
        public virtual void CompleteQuest(Player player)
        {
          
            IsCompleted = true;
            IncreaseCompletionCount(); 
            int reward = CalculateReward();  
            player.Gold += reward;  
            Console.WriteLine($"퀘스트 '{Name}'을 완료했습니다! 보상: {reward} 골드.");

            ResetProgress(); // 퀘스트 초기화
        }

        // 퀘스트 클리어 카운트 증가
        private void IncreaseCompletionCount()
        {
            CompletionCount++;
        }

        // 기본 보상 계산
        protected virtual int CalculateReward()
        {
            return 150; 
        }

        // 각 퀘스트마다 진행 상황을 초기화하는 메서드 (상속 클래스에서 구현)
        public abstract void ResetProgress();

        // 몬스터 처치 퀘스트
        public class MonsterKillQuest : Quest
        {
            private int monsterKillTargetCount;
            private int monsterKillCurrentCount;

            public MonsterKillQuest(int targetCount) : base("(반복)몬스터 처치하기")
            {
                monsterKillTargetCount = targetCount;
                monsterKillCurrentCount = 0;
            }

            public void MonsterKilled()
            {
                if (IsCompleted) return;

                monsterKillCurrentCount++;
                CheckProgress();
            }

            public override void CheckProgress()
            {
                if (monsterKillCurrentCount >= monsterKillTargetCount)
                {
                    IsCompleted = true;
                }
            }

            // 몬스터 처치 퀘스트 진행도 초기화
            public override void ResetProgress()
            {
                IsCompleted = false;
                monsterKillCurrentCount = 0;
            }

            // 보상 계산
            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }

        // 스테이지 클리어 퀘스트
        public class StageClearQuest : Quest
        {
            public StageClearQuest() : base("스테이지 클리어") { }

            public void StageCleared()
            {
                if (IsCompleted) return;

                IsCompleted = true;
                CheckProgress();
            }

            public override void CheckProgress()
            {
                
            }

            // 스테이지 클리어 퀘스트 진행도 초기화
            public override void ResetProgress()
            {
                IsCompleted = false;
            }

            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }

        // 아이템 구매 퀘스트
        public class ItemPurchaseQuest : Quest
        {
            private int itemPurchaseTargetCount;
            private int itemPurchaseCurrentCount;

            public ItemPurchaseQuest(int targetCount) : base("(반복)아이템 구매")
            {
                itemPurchaseTargetCount = targetCount;
                itemPurchaseCurrentCount = 0;
            }

            public void ItemPurchased()
            {
                if (IsCompleted) return;

                itemPurchaseCurrentCount++;
                CheckProgress();
            }

            public override void CheckProgress()
            {
                if (itemPurchaseCurrentCount >= itemPurchaseTargetCount)
                {
                    IsCompleted = true;
                }
            }

            // 아이템 구매 퀘스트 진행도 초기화
            public override void ResetProgress()
            {
                IsCompleted = false;
                itemPurchaseCurrentCount = 0;
            }

            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }
    }
}
