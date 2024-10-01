namespace TextRPG_Team12
{
    public class Miscellaneous : ItemType
    {


        public string Name { get; set; }
        public string Info { get; set; }
        public int HasNum { get; set; }      //소지량

        public int Price { get; }


        public Miscellaneous(string name, string info, int price, int hasnum)
            :base(name, info, price, hasnum)
        {

     
            Name = name;
            Info = info;
            Price = price;
            HasNum = hasnum;

        }



    }



}
