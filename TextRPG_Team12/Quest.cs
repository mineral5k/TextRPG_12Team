using System;

namespace TextRPG_Team12
{
    public abstract class Quest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; protected set; }

        public Quest(string name)
        {
            Name = name;
            IsCompleted = false;
        }

        public abstract void CheckProgress();
        public abstract void CompleteQuest(Player player); 
    }

    // 퀘스트 1 (반복) 몬스터 처치하기 
    public class MonsterKillQuest : Quest
    {
        public int MonsterKillTargetCount { get; private set; }
        private int monsterKillCurrentCount;
        private int clearCount; 

        public MonsterKillQuest(int monsterKillTargetCount) : base("(반복)몬스터 처치하기")
        {
            MonsterKillTargetCount = monsterKillTargetCount;
            monsterKillCurrentCount = 0;
            clearCount = 0; 
        }

        // 몬스터 잡았을 때
        public void MonsterKilled()
        {
            if (IsCompleted)
            {
                Console.WriteLine($"퀘스트 '{Name}'은(는) 완료되었습니다.");
                return;
            }

            monsterKillCurrentCount++;
            Console.WriteLine($"몬스터 처치 수 : {monsterKillCurrentCount}/{MonsterKillTargetCount}");

            CheckProgress();
        }

        // 퀘스트 완료 여부 확인
        public override void CheckProgress()
        {
            if (monsterKillCurrentCount >= MonsterKillTargetCount)
            {
                IsCompleted = true;
                clearCount++; 
                Console.WriteLine($"퀘스트 '{Name}' 완료 !");
            }
        }

        // 보상 지급
        public override void CompleteQuest(Player player)
        {
            int reward = (int)(150 * Math.Pow(1.2, clearCount - 1)); 
            player.Gold += reward; // 
            Console.WriteLine($"보상으로 {reward} 골드를 획득했습니다!");
        }

        public void ResetQuest()
        {
            monsterKillCurrentCount = 0;
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");
        }
    }

    // 퀘스트 2 (반복) 스테이지 클리어 퀘스트
    public class StageClearQuest : Quest
    {
        private int clearCount; 

        public StageClearQuest() : base("스테이지 클리어 퀘스트")
        {
            clearCount = 0; 
        }

        // 스테이지 클리어
        public void StageCleared()
        {
            if (IsCompleted)
            {
                Console.WriteLine($"퀘스트 '{Name}'은(는) 이미 완료되었습니다.");
                return;
            }

            // 퀘스트 완료 처리
            IsCompleted = true;
            clearCount++; 
            Console.WriteLine($"퀘스트 '{Name}'이(가) 완료되었습니다!");
        }

        // 퀘스트 완료 여부 확인 
        public override void CheckProgress()
        {
            
        }

        // 보상 지급
        public override void CompleteQuest(Player player)
        {
            int reward = (int)(150 * Math.Pow(1.2, clearCount - 1)); 
            player.Gold += reward; 
            Console.WriteLine($"보상으로 {reward} 골드를 획득했습니다!");
        }

        public void ResetQuest()
        {
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");
        }
    }

    // 퀘스트 3 (반복) 아이템 구매하기 퀘스트
    public class ItemPurchaseQuest : Quest
    {
        public int ItemPurchaseTargetCount { get; private set; }
        private int itemPurchaseCurrentCount;
        private int clearCount; 

        public ItemPurchaseQuest(int itemPurchaseTargetCount) : base("(반복)아이템 구매 퀘스트")
        {
            ItemPurchaseTargetCount = itemPurchaseTargetCount;
            itemPurchaseCurrentCount = 0;
            clearCount = 0; 
        }

        // 아이템 구매 시 호출
        public void ItemPurchased()
        {
            if (IsCompleted)
            {
                Console.WriteLine($"퀘스트 '{Name}'은(는) 이미 완료되었습니다.");
                return;
            }

            itemPurchaseCurrentCount++;
            Console.WriteLine($"아이템 구매 수 : {itemPurchaseCurrentCount}/{ItemPurchaseTargetCount}");

            CheckProgress();
        }

        public override void CheckProgress()
        {
            if (itemPurchaseCurrentCount >= ItemPurchaseTargetCount)
            {
                IsCompleted = true;
                clearCount++; 
                Console.WriteLine($"퀘스트 '{Name}' 완료 !");
            }
        }

        // 보상 지급
        public override void CompleteQuest(Player player)
        {
            int reward = (int)(150 * Math.Pow(1.2, clearCount - 1)); 
            player.Gold += reward; 
            Console.WriteLine($"보상으로 {reward} 골드를 획득했습니다!");
        }

        public void ResetQuest()
        {
            itemPurchaseCurrentCount = 0;
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");
        }
    }
}
