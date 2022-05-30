using System;
using TaxApp.Models;
namespace TaxApp.Services
{
    public class CartItems
    {
        private IGoodValidation goodValidation;
        private Models.ApplicationUser user;
        public CartItems(IGoodValidation goodValidation, Models.ApplicationUser user)
        {
            this.user = user;
            this.goodValidation = Argument.NotNull(goodValidation, nameof(goodValidation));
        }

        public void AddToCart(string name, GoodType type, double price)
        {
            Models.Good good =  goodValidation.ValidateInput(name, type, price);
            user.Cart.AddToCart(good);
        }

        public void RemoveFromCart(string name)
        {
            user.Cart.RemoveGoodByName(name);
        }
        
        public Models.ApplicationUser User
        {
            get { return this.user; }
        }
    }
}
