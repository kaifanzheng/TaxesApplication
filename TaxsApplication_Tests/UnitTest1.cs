using System;
using Xunit;

namespace TaxsApplication_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void test_ApplicationUser_API()
        {
            User_API user_api = new User_API("kaifan");
            Good goodOne = new Good(12.49, GoodType.taxFree, "Book");
            Good goodTwo = new Good(14.99, GoodType.regular, "music");
            Good goodThree = new Good(0.85, GoodType.taxFree, "chocolate bar");
            user_api.AddToCart(goodOne);
            user_api.AddToCart(goodTwo);
            user_api.AddToCart(goodThree);
        }
    }
}
