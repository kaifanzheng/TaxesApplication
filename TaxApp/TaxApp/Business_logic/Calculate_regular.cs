using System;
using TaxApp.Models;

namespace TaxApp.Business_logic
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
            return aGood.Price * 0.10;
        }
    }
}
