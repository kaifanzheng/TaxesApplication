using System;
namespace TaxApp.Models
{
    public class Good
    {
        private string name;
        private double price;
        private GoodType type;
        public Good(string name,GoodType type,double price)
        {
            this.type = type;
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public GoodType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
