using System;
using TaxApp.Models;

namespace TaxApp.Business_logic
{
    public class Calculate_taxFree:ICalculation
    {
        private Good aGood;
        public Calculate_taxFree(Good aGood)
        {
            this.aGood = aGood;
        }


        public double CalculateTax()
        {
            return aGood.Price * 0.00;
        }
    }
}
