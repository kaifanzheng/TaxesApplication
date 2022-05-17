using System;
using TaxesApplication.Business_logic;
using TaxesApplication.Models;
using TaxesApplication.Services;

namespace TaxesApplication.API_Console
{
    public class User_API
    {
        private ApplicationUser user;
        private ApplicationUser_service service;
        public User_API(string userID)
        {
            ApplicationUser_validation val = new ApplicationUser_validation();
            Classification classify = new Classification();
            service = new ApplicationUser_service(val, classify);
            this.user = service.CreateUser(userID);
        }
        public string UserTotalCost()
        {
            return service.GenerateRecipt(this.user);
        }
        public void AddToCart(double price,GoodType type,string name)
        {
            service.AddToCart(this.user,new Good(price,type,name));
   
        }
    }
}
