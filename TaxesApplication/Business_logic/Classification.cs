using System;
using TaxesApplication.Models;

namespace TaxesApplication.Business_logic
{
    public class Classification : IClassification
    {
        public ICalculation CreateCalculation(Good good)
        {
            if((int)good.GetGoodType() == 1)
            {
                return (ICalculation)new Calculate_regular(good);
            }
            else if ((int)good.GetGoodType() == 2)
            {
                return (ICalculation)new Calculate_taxFree(good);
            }
            else if ((int)good.GetGoodType() == 3)
            {
                return (ICalculation)new Calculate_importedRegular(good);
            }
            else if ((int)good.GetGoodType() == 4)
            {
                return (ICalculation)new Calculate_importedTaxFree(good);
            }
            return null;
        }
    }
}
