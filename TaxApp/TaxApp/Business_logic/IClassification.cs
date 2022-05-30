using System;
using TaxApp.Models;

namespace TaxApp.Business_logic
{
    public interface IClassification
    {
        ICalculation CreateCalculation(Good good);
    }
}
