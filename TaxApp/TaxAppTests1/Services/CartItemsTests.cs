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
    public class CartItemsTests
    {

        [TestMethod()]
        public void AddToCartTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "Book";
            Models.GoodType type = Models.GoodType.taxFree;
            double price = 12.49;
            item_Ser.AddToCart(name, type, price);

            Assert.IsTrue(item_Ser.User.Cart.FindItemByName(name) != null);
            Assert.IsTrue(item_Ser.User.Cart.FindItemByName(name).Good.Type.Equals(type));
            Assert.IsTrue(item_Ser.User.Cart.FindItemByName(name).Good.Price == price);
        }

        [TestMethod()]
        public void AddToCartWithEmptyNameTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "";
            Models.GoodType type = Models.GoodType.taxFree;
            double price = 12.49;
            try
            {
                item_Ser.AddToCart(name, type, price);
            }
            catch(InvalidOperationException e)
            {
                Assert.IsTrue(e.Message.Equals("name of good cannot be empty"));
            }
        }
        [TestMethod()]
        public void AddToCartWithNegitiveTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "Book";
            Models.GoodType type = Models.GoodType.taxFree;
            double price = -12.49;
            try
            {
                item_Ser.AddToCart(name, type, price);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsTrue(e.Message.Equals("price cannot be negtive"));
            }
        }
        [TestMethod()]
        public void AddToCartWithUndefinedTypeTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "Book";
            Models.GoodType type = Models.GoodType.Undefined;
            double price = 12.49;
            try
            {
                item_Ser.AddToCart(name, type, price);
            }
            catch (InvalidOperationException e)
            {
                Assert.IsTrue(e.Message.Equals("cannot calculate undefine good type"));
            }
        }


        [TestMethod()]
        public void RemoveFromCartTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "Book";
            Models.GoodType type = Models.GoodType.taxFree;
            double price = 12.49;
            item_Ser.AddToCart(name, type, price);

            item_Ser.RemoveFromCart(name);
            Assert.IsTrue(user.Cart.FindItemByName(name).Amount == 0);
        }
        [TestMethod()]
        public void RemoveOneGoodFromAThreeAmountItem()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            CartItems item_Ser = new CartItems(new Services.GoodValidation(), user);

            string name = "Book";
            Models.GoodType type = Models.GoodType.taxFree;
            double price = 12.49;
            item_Ser.AddToCart(name, type, price);
            item_Ser.AddToCart(name, type, price);
            item_Ser.AddToCart(name, type, price);

            item_Ser.RemoveFromCart(name);
            Assert.IsTrue(user.Cart.FindItemByName(name).Amount == 2);
        }
    }
}