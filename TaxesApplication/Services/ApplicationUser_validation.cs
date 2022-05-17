using System;
using TaxesApplication.Models;

namespace TaxesApplication.Services
{
    public class ApplicationUser_validation:IValidation
    {
        public Good IsGoodValid(Good aGood)
        {
            Good good = Argument.NotNull(aGood, nameof(aGood));
            //when the price is invaild
            if (good.GetPrice() < 0)
            {
                throw new InvalidOperationException("price cannot be negtive");
            }
            //when the good name is invaild
            if (good.GetName() == null || good.GetName().Equals(""))
            {
                throw new InvalidOperationException("name of good cannot be empty");

            }
            //when the type of good is undefine
            if ((int)good.GetGoodType() == 0)
            {
                throw new InvalidOperationException("cannot calculate undefine good type");
            }
            
            return good;

        }
    }
}
