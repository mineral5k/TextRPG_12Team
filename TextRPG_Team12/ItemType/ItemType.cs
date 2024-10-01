using System.Diagnostics;
using System.Xml.Linq;

namespace TextRPG_Team12
{
    public abstract class ItemType
    {


        public int ItemCount { get; set; }

        public string Name { get; set; }
        public string Info { get; set; }
        public int Price { get; set; }


        public ItemType(string name, string info, int price)
        {
            Name = name;
            Info = info;
            Price = price;
        }


        public string ItemInfoText()
        {

            return $"{Name} | {Info} | X {ItemCount}";


        }



    }




}
