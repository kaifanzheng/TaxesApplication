using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxApp.Services.Tests
{
    [TestClass()]
    public class CalculateReciptTests
    {
        [TestMethod()]
        public void CalculateReciptTestOne()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            item_Ser.AddToCart("Book", Models.GoodType.taxFree, 12.49);
            item_Ser.AddToCart("music", Models.GoodType.regular, 14.99);
            item_Ser.AddToCart("chocolate bar", Models.GoodType.taxFree, 0.85);

            CalculateRecipt recipt_Ser = new CalculateRecipt(new Business_logic.Classification(), user.Cart);
            string recipt = recipt_Ser.GenerateRecipt();
            string expectation = "*1 Book: 12.49\n*1 music: 16.49\n*1 chocolate bar: 0.85\n*Sales Tax: 1.50 Total: 29.83";
            Assert.IsTrue(recipt.Equals(expectation));
        }
        [TestMethod()]
        public void CalculateReciptTwo()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            item_Ser.AddToCart("imported box of chocolates", Models.GoodType.importedTaxFree, 10.00);
            item_Ser.AddToCart("imported bottle of perfum", Models.GoodType.importedRegular, 47.5);

            CalculateRecipt recipt_Ser = new CalculateRecipt(new Business_logic.Classification(), user.Cart);
            string recipt = recipt_Ser.GenerateRecipt();
            string expectation = "*1 imported box of chocolates: 10.50\n*1 imported bottle of perfum: 54.63\n*Sales Tax: 7.63 Total: 65.13";
            Assert.IsTrue(recipt.Equals(expectation));
        }
    }
}