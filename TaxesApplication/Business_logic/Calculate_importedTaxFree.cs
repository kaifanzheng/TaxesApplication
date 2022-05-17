using System;
using TaxesApplication.Models;

namespace TaxesApplication.Business_logic
{
    public class Calculate_importedTaxFree:ICalculation
    {
        private Good aGood;
        public Calculate_importedTaxFree(Good aGood)
        {
            this.aGood = aGood;
        }

        public double CalculateTax()
        {
            return aGood.GetPrice() * 0.05;
        }
    }
}
