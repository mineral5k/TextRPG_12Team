using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team12
{
    public class Potion : ItemType
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int Type {  get; set; }          // 1= 체력 포션 2 = 마나 포션 3~= 기타 포션
        public int Recovery { get; set; }       //회복량
        public int HasNum { get; set; }      //소지량

        public int Price { get; }

        public Potion (string name, string info, int type, int recovery) :base(name,info, 500, 1)
        {
            Name = name;
            Info = info;
            Type = type;
            Recovery = recovery;

        }




        public void UsePotion(Player player)                                              //소모 아이템 사용 메서드
        {
            Console.WriteLine($"{Name}을 사용하였습니다.");
            if (Type == 1)                                                               //아이템의 타입을 먼저 확인
            {
                player.Health += Recovery;
                Console.WriteLine($"체력을 {Recovery} 회복  현재 체력 : {player.Health}");
            }

            else if (Type == 2)
            {
                player.Mana += Recovery;
                Console.WriteLine($"마나를 {Recovery} 회복  현재 마나 : {player.Mana}");
            }

            HasNum -= 1;                                                                // 사용 후 소지 개수 감소
        }

    }


}
