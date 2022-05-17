using System;
using TaxesApplication.API_Console;
using TaxesApplication.Models;

namespace TaxesApplication.UI_Console
{
    public class User_UI
    {
        private User_API user_API;
        public User_UI(User_API user_api)
        {
            this.user_API = user_api;
        }
        public void ConsoleOut()
        {
            Console.Write(this.user_API.UserTotalCost());
        }
    }
}
