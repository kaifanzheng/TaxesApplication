using System;
using System.Collections;
using System.Collections.Generic;

namespace TaxApp.Models
{
    public class Cart
    {
        private List<CartItems> goods;//keys are the type of good in int

        public Cart()
        {
            this.goods = new List<CartItems>();
        }

        public CartItems FindItemByName(string goodName)
        {
            foreach(CartItems item in goods)
            {
                if(item.Good.Name.Equals(goodName))
                {
                    return item;
                }
            }
            return null;
        }

        public void AddToCart(Good good)
        {
            CartItems item = FindItemByName(good.Name);
            if (item != null)
            {
                item.AddGood();
            }
            else
            {
                goods.Add(new CartItems(good));
            }
        }

        public void RemoveGoodByName(string name)
        {
            CartItems item = FindItemByName(name);
            if (item != null)
            {
                item.RemoveGood();
            }
        }

        public List<CartItems> Goods
        {
            get { return goods; }
        }

    }
}
