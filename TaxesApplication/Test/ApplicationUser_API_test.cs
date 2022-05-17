using System;
using TaxesApplication.API_Console;
using TaxesApplication.Models;
using Xunit;
namespace TaxesApplication.Test
{
    public class ApplicationUser_API_test
    {
        [Fact]
        public void Test_ApplicationUser_API_CaseOne()
        {
            //Arrange
            string expectation = "*1 Book: 12.49\n*1 music: 16.49\n*1 chocolate bar: 0.85\n*Sales Tax: 1.50 Total: 29.83";
            //act
            User_API user_api = new User_API("kaifan");
            user_api.AddToCart(12.49, GoodType.taxFree, "Book");
            user_api.AddToCart(14.99, GoodType.regular, "music");
            user_api.AddToCart(0.85, GoodType.taxFree, "chocolate bar");
            string actual = user_api.UserTotalCost();
            //Assert
            Assert.Equal(actual, expectation);

        }
        [Fact]
        public void Test_ApplicationUser_API_CaseTwo()
        {
            //Arrange
            string expectation = "*1 imported box of chocolates: 10.50\n*1 imported bottle of perfume: 54.63\n*Sales Tax: 7.63 Total: 65.13";
            //act
            User_API user_api = new User_API("kaifan");
            user_api.AddToCart(10.00, GoodType.importedTaxFree, "imported box of chocolates");
            user_api.AddToCart(47.5, GoodType.importedRegular, "imported bottle of perfume");
            string actual = user_api.UserTotalCost();
            Console.WriteLine(expectation);
            Console.WriteLine(actual);
            //Assert
            Assert.Equal(actual, expectation);

        }
    }
}
