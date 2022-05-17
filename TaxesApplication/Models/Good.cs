using System;
namespace TaxesApplication.Models
{
    public class Good
    {
        private double price;
        private GoodType goodType;
        private string name;
        //constructer for good class
        public Good(double price,GoodType goodType,string name)
        {
            this.price = price;
            this.goodType = goodType;
            this.name = name;
        }

        //adders and setters for member variables
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public double GetPrice()
        {
            return this.price;
        }
        public void SetGoodType(GoodType goodType)
        {
            this.goodType = goodType;
        }
        public GoodType GetGoodType()
        {
            return this.goodType;//return the interger to determine the goodtype
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        //over write ToString() method
        public override string ToString()
        {
            string messege = "item name: " + this.name + ", item price: " + this.price + ", type: " + this.GetGoodType().ToString();
            return messege;
        }

    }

    //public class SmallTest
    //{
    //    static void Main(string[] args)
    //    {
    //        Good goodOne = new Good(10.0, GoodType.imported, "BX23");

    //        ApplicationUser aUser = new ApplicationUser("123");
    //        aUser.AddToCart(goodOne);
    //        Console.WriteLine(aUser.GetUserId());

    //        Console.WriteLine(aUser.GetCart()[0]);

    //    }
    //}
}