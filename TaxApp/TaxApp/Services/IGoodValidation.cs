using System;
using TaxApp.Models;
namespace TaxApp.Services
{
    public interface IGoodValidation
    {
        public Models.Good ValidateInput(string name, GoodType type, double price);
    }
}
