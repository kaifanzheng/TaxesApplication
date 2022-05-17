using System;
using TaxesApplication.Models;

namespace TaxesApplication.Business_logic
{
    public interface IClassification
    {
        ICalculation CreateCalculation(Good good);
    }
}
