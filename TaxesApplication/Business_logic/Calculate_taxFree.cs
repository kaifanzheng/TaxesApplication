using System;
using TaxesApplication.Models;

namespace TaxesApplication.Business_logic
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
            return aGood.GetPrice() * 0.00;
        }
    }
}
