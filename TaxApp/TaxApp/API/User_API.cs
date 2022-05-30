using System;
namespace TaxApp.API
{
    public class User_API
    {
        private Services.ApplicationUser user_Service;
        private Services.CartItems cartService;
        private Models.ApplicationUser user;
        private Services.CalculateRecipt calculateRecipt;

        public User_API(string email, string name)
        {
            user_Service = new Services.ApplicationUser(new Services.UserValidation());
            this.user = user_Service.CreateUser(email, name);
            cartService = new Services.CartItems(new Services.GoodValidation(),this.user);
            calculateRecipt = new Services.CalculateRecipt(new Business_logic.Classification(),user.Cart);
        }

        public void AddToCart(string name, Models.GoodType type, double price)
        {
            cartService.AddToCart(name, type, price);
        }

        public void RemoveFromCart(string name)
        {
            cartService.RemoveFromCart(name);
        }

        public string UserTotalCost()
        {
            return calculateRecipt.GenerateRecipt();
        }
    }
}
