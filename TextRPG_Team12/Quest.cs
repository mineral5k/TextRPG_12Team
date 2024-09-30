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


    //퀘스트 1 (반복) 몬스터 처치하기 
    public class RepeatableQuest : Quest
    {
        public int RepaeatquesttargetCount;
        int RepeatquestcurrentCount;

        public RepeatableQuest(int RepaeatquesttargetCount) : base("(반복)몬스터 처치하기")
        {
            this.RepaeatquesttargetCount = RepaeatquesttargetCount;
            RepeatquestcurrentCount = 0;
        }

        // 몬스터 잡았을 때
        public void MonsterKilled()
        {
            if (IsCompleted)
            {
                Console.WriteLine($"퀘스트 '{Name}'이(가) 완료되었습니다.");
                return;
            }

            RepeatquestcurrentCount++;
            Console.WriteLine($"몬스터 처치 수 : {RepeatquestcurrentCount}/{RepaeatquesttargetCount}");

            CheckProgress();
        }

        // 퀘스트 완료 여부 확인
        public override void CheckProgress()
        {
            if (RepeatquestcurrentCount >= RepaeatquesttargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"퀘스트 '{Name}' 완료 !");
            }
        }

        public void ResetQuest()
        {
            RepeatquestcurrentCount = 0;
            IsCompleted = false;
            Console.WriteLine($"퀘스트 '{Name}'를 다시 진행할 수 있습니다.");

        }
    }
}