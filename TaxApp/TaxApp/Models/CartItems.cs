using System;
namespace TaxApp.Models
{
    public class CartItems
    {
        private Good good;
        private int amount;
        public CartItems(Good good)
        {
            this.good = good;
            this.amount = 1;
        }

        public Good Good
        {
            get { return this.good; } 
        }

        public int Amount
        {
            get { return this.amount; }
        }

        public void AddGood()
        {
            this.amount++;
        }

        public void RemoveGood()
        {
            if (this.amount > 0)
            {
                this.amount--;
            }
        }
    }
}
