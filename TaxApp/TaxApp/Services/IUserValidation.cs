using System;
using TaxApp.Models;
namespace TaxApp.Services
{
    public interface IUserValidation
    {
        public Models.ApplicationUser ValidateInput(string email, string name);
    }
}
