using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum EquipmentType
{ Armor, Weapon }


internal class Equipment
{
    public string Name { get; }
    public string Info { get; }
    public int Defense { get; }
    public int Attack { get; }
    public int Price { get; }
    public bool IsPurchased { get; set; } // 구매
    public bool IsEquipped { get; set; } // 장착
    public EquipmentType Type { get; }


    public string EquipmentTypeText
    {
        get
        {
            return Type == EquipmentType.Weapon ? "공격력" : "방어력";
        }
    }


    public Equipment(string name, string info, int defense, int attack, int price, EquipmentType type, bool ispurchased = false, bool isEquipped = false)
    {
        Name = name;
        Info = info;
        Defense = defense;
        Attack = attack;
        Price = price;
        IsPurchased = ispurchased;
        IsEquipped = isEquipped;
        Type = type;
    }

    public string EquipmentStatText()
    {
        return $"{Name}   | {EquipmentTypeText} + {Info} | ";
    }

}
