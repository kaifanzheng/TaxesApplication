using System;
using TaxApp.Models;

namespace TaxApp.Business_logic
{
    public class Classification : IClassification
    {
        public ICalculation CreateCalculation(Good good)
        {
            switch (good.Type)
            {
                case GoodType.regular: return (ICalculation)new Calculate_regular(good);
                case GoodType.taxFree: return (ICalculation)new Calculate_taxFree(good);
                case GoodType.importedRegular: return (ICalculation)new Calculate_importedRegular(good);
                case GoodType.importedTaxFree: return (ICalculation)new Calculate_importedTaxFree(good);
                case GoodType.Undefined: return null;
                default: return null;
            }
        }
    }
}
