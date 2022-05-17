using System;
using TaxesApplication.Models;

namespace TaxesApplication.Business_logic
{
    public class Calculate_regular:ICalculation
    {
        private Good aGood;
        public Calculate_regular(Good aGood)
        {
            this.aGood = aGood;
        }

        public double CalculateTax()
        {
            return aGood.GetPrice() * 0.10;
        }
    }
}
