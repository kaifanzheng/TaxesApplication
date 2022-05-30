using System;
using TaxApp.Models;

namespace TaxApp.Services
{
    public class GoodValidation : IGoodValidation
    {
        public Models.Good ValidateInput(string name, GoodType type, double price)
        {
            if (price < 0)
            {
                throw new InvalidOperationException("price cannot be negtive");
            }

            if (name == null || name.Equals(""))
            {
                throw new InvalidOperationException("name of good cannot be empty");

            }
 
            if ((int)type == 0)
            {
                throw new InvalidOperationException("cannot calculate undefine good type");
            }

            return new Models.Good(name,type,price);

        }
    }
}
