using System;
namespace TaxApp.Services
{
    public class UserValidation:IUserValidation
    {
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public Models.ApplicationUser ValidateInput(string email, string name)
        {
            if(email == null || name == null||email.Equals("")|| name.Equals(""))
            {
                throw new InvalidOperationException("input cannot be emtpy");
            }
            if (!IsValidEmail(email))
            {
                throw new InvalidOperationException("email is not valid");
            }
            return new Models.ApplicationUser(email,name);
        }
    }
}
