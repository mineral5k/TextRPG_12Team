using System.Diagnostics;
using System.Xml.Linq;

namespace TextRPG_Team12
{
    public abstract class ItemType
    {


        public int HasNum { get; set; }

        public string Name { get; set; }
        public string Info { get; set; }
        public int Price { get; set; }


        public ItemType(string name, string info, int price, int hasnum)
        {
            Name = name;
            Info = info;
            Price = price;
            HasNum = hasnum;
        }


        public string ItemInfoText()
        {

            return $"{Name} | {Info} | X {HasNum}";


        }



    }




}
