using System;
using TaxApp.Models;

namespace TaxApp.Business_logic
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
            return aGood.Price * 0.05;
        }
    }
}
