using System;
using TaxApp.Models;
namespace TaxApp.Services
{
    public class ApplicationUser
    {
        private IUserValidation userValidation;
        public ApplicationUser(IUserValidation userValidation)
        {
            this.userValidation = Argument.NotNull(userValidation,nameof(userValidation));
        }

        public Models.ApplicationUser CreateUser(string email, string name)
        {
            return userValidation.ValidateInput(email, name);
        }
    }
}
