namespace TextRPG_Team12
{
    public class Miscellaneous : ItemType
    {


        public string Name { get; set; }
        public string Info { get; set; }
        public int HasNumber { get; set; }      //소지량

        public int Price { get; }


        public Miscellaneous(string name, string info, int price)
        {

     
            Name = name;
            Info = info;
            Price = price;
        

        }



    }



}
