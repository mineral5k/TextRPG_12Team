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
        public virtual void CompleteQuest(Player player)
        {
            if (IsCompleted)
            {
                Console.WriteLine($"퀘스트 '{Name}'은 이미 완료되었습니다.");
                return;
            }

            IsCompleted = true;
            IncreaseCompletionCount(); 
            int reward = CalculateReward();  
            player.Gold += reward;  
            Console.WriteLine($"퀘스트 '{Name}'을 완료했습니다! 보상: {reward} 골드.");
        }

        private void IncreaseCompletionCount()
        {
            CompletionCount++;
        }

        protected virtual int CalculateReward()
        {
            return 150; 
        }

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

            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }

        public class StageClearQuest : Quest
        {
            public StageClearQuest() : base("스테이지 클리어 퀘스트") { }

            public void StageCleared()
            {
                if (IsCompleted) return;

                IsCompleted = true;
                CheckProgress();
            }

            public override void CheckProgress()
            {
                
            }

            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }

        public class ItemPurchaseQuest : Quest
        {
            private int itemPurchaseTargetCount;
            private int itemPurchaseCurrentCount;

            public ItemPurchaseQuest(int targetCount) : base("(반복)아이템 구매 퀘스트")
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

            protected override int CalculateReward()
            {
                return (int)(150 * Math.Pow(1.2, CompletionCount)); 
            }
        }



    }

}
