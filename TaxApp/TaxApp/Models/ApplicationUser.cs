using System;
namespace TaxApp.Models
{
    public class ApplicationUser
    {
        private Cart cart;
        private string email;//unique id
        private string name;

        public ApplicationUser(string email, string name)
        {
            this.cart = new Cart();
            this.email = email;
            this.name = name;
        }

        public Cart Cart
        {
            get { return this.cart; }
            set { this.cart = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
