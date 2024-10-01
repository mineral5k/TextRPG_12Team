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
    }

    // 퀘스트 1 (반복) 몬스터 처치하기 
    public class MonsterKillQuest : Quest
    {
        public int MonsterKillTargetCount { get; private set; }
        private int monsterKillCurrentCount;

        public MonsterKillQuest(int monsterKillTargetCount) : base("(반복)몬스터 처치하기")
        {
            MonsterKillTargetCount = monsterKillTargetCount;
            monsterKillCurrentCount = 0;
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
                Console.WriteLine($"퀘스트 '{Name}' 완료 !");
            }
        }

        public void ResetQuest()
        {
            monsterKillCurrentCount = 0;
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");
        }
    }

    // 퀘스트2 (반복)스테이지 클리어 퀘스트
    public class StageClearQuest : Quest
    {
        public StageClearQuest() : base("스테이지 클리어 퀘스트")
        {

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
            Console.WriteLine($"퀘스트 '{Name}'이(가) 완료되었습니다!");
        }

        // 퀘스트 완료 여부 확인 (필요시 사용)
        public override void CheckProgress()
        {
          //
        }

        // 퀘스트 초기화 메서드
        public void ResetQuest()
        {
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");

        }

        // 퀘스트 3 (반복) 아이템 구매하기 퀘스트
        public class ItemPurchaseQuest : Quest
        {
            public int ItemPurchaseTargetCount { get; private set; }
            private int itemPurchaseCurrentCount;

            public ItemPurchaseQuest(int itemPurchaseTargetCount) : base("(반복)아이템 구매 퀘스트")
            {
                ItemPurchaseTargetCount = itemPurchaseTargetCount;
                itemPurchaseCurrentCount = 0;
            }

            // 아이템 구매 시 호출
            // 플레이어 buyshop이랑 병합 
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
                    Console.WriteLine($"퀘스트 '{Name}' 완료 !");
                }
            }

            public void ResetQuest()
            {
                itemPurchaseCurrentCount = 0;
                IsCompleted = false;
                Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");
            }


        }
    }
}


    

