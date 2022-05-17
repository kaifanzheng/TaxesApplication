using System;
using TaxesApplication.Models;
namespace TaxesApplication.Services
{
    public interface IValidation
    {
        Good IsGoodValid(Good aGood);

    }
}
