using System.Diagnostics;
using System.Xml.Linq;

namespace TextRPG_Team12
{
    public  class ItemType
    {


        public int HasNum { get; set; }

        public string Name;
        public string Info;
        public int Price;

     

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
