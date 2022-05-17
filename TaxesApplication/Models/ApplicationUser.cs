using System.Collections;

namespace TaxesApplication.Models
{
    public class ApplicationUser
    {
        private string userId;
        private ArrayList cart;

        public ApplicationUser(string userId)
        {
            this.userId = userId;
            cart = new ArrayList();
        }

        //getter and setters
        public void SetUserId(string userId)
        {
            this.userId = userId;
        }
        public string GetUserId()
        {
            return this.userId;
        }
        public void AddToCart(Good aGood)
        {
            this.cart.Add(aGood);
        }

        public ArrayList GetCart()
        {
            return this.cart;
        }
    }
}