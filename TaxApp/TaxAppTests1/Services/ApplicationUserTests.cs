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
    public class ApplicationUserTests
    {

        [TestMethod()]
        public void CreateUserTest()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "1210625079@gmail.com";
            Models.ApplicationUser user= user_Ser.CreateUser(email, username);
            Assert.IsTrue(user.Name.Equals(username));
            Assert.IsTrue(user.Email.Equals(email));
        }
        [TestMethod()]
        public void CreateUserUsingEmptyEmailAndUsername()
        {
            string errorMes = "";
            try
            {
                ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
                string username = "";
                string email = "";
                Models.ApplicationUser user = user_Ser.CreateUser(email, username);
            }
            catch(InvalidOperationException e)
            {
                errorMes = e.Message;
            }
            Assert.IsTrue(errorMes.Equals("input cannot be emtpy"));
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException), "email is not valid")]
        public void CreateUserUsingInvalidEmail()
        {
            ApplicationUser user_Ser = new ApplicationUser(new Services.UserValidation());
            string username = "Ethen Winter";
            string email = "teksystems";
            Models.ApplicationUser user = user_Ser.CreateUser(email, username);
        }
    }
}