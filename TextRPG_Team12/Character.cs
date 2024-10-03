using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace TextRPG_Team12
{
    public class Character
    {


       public string Name { get; set; }

       public int Level { get; set; }

       public int Health { get; set; }

       public int MaxHealth {  get; set; }

       public int AttackPower { get; set; }
       
       public bool IsDead => Health <= 0;
            
       public int Evasion { get; set; }
     
       public int Critical { get; set; }



        public virtual void  TakeDamage(int damage)
        {
            //Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다.");
            UImanager.BlinkText($"{Name}이(가) {damage}의 데미지를 받았습니다.", 1, 200, ConsoleColor.DarkRed, ConsoleColor.White);

            Health -= damage;
            if (IsDead) //Console.WriteLine($"{Name}이(가) 죽었습니다."); 
                UImanager.BlinkText($"{Name}이(가) 죽었습니다.", 1, 200, ConsoleColor.DarkRed, ConsoleColor.Red);
            else
                Console.WriteLine();
                Console.WriteLine($"남은 체력: {Health}");

        }

        public void Attack(Character character)
        {
            int r = (AttackPower % 10 == 0) ? (AttackPower / 10) : (AttackPower / 10 + 1);
            int damage = new Random().Next(AttackPower - r, AttackPower + r + 1);

            Console.Write("\u001b[48;2;30;30;30m\u001b[38;2;255;255;255m");
            Console.WriteLine($"{Name}의 공격!\u001b[0m");

            if (new Random().Next(1, 101) <= Evasion)
            {
                //Console.WriteLine("공격이 빗나갔습니다.");
                UImanager.BlinkText("공격이 빗나갔습니다.", 1, 200, ConsoleColor.Red, ConsoleColor.White);

            }
            else if (new Random().Next(1, 101) <= Critical)
            {
                //Console.Write("크리티컬! ");
                UImanager.BlinkText("크리티컬!", 1, 200, ConsoleColor.Cyan, ConsoleColor.White);
                character.TakeDamage((int)Math.Round(damage * 1.5));

            }
            else
            { 
                character.TakeDamage(damage);

            }
        }


        public void ItemArray(ref List<ItemType> itemList)
        { 
        
            var sortedItemList = itemList.OrderBy(ItemOrder).ToList();
                itemList = sortedItemList;
       
        }

        public int ItemOrder(ItemType itemorder)
        {

            return itemorder switch
            {
                Equipment => 0,
                Potion => 1,
                Miscellaneous => 2,
                _ => 3
            };
        }


    }
}
