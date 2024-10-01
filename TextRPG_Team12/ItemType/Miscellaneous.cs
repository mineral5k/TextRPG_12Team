namespace TextRPG_Team12
{
    public class Miscellaneous : ItemType
    {


        public string Name { get; set; }
        public string Info { get; set; }
        public int HasNum { get; set; }      //소지량

        public int Price { get; }


        public Miscellaneous(string name, string info, int price)
            :base(name, info, price, 1)
        {

     
            Name = name;
            Info = info;
            Price = price;
            HasNum = 1;

        }



    }



}
