using System;
using TaxApp.Business_logic;
using TaxApp.Models;
namespace TaxApp.Services
{
    public class CalculateRecipt
    {
        private IClassification classification;
        private Cart cart;
        public CalculateRecipt(IClassification classification, Cart cart)
        {
            this.classification = Argument.NotNull(classification,nameof(classification));
            this.cart = cart;
        }

        private double CalculateCartItemTax(Models.CartItems items)
        {
            double tax = classification.CreateCalculation(items.Good).CalculateTax();
            return tax * items.Amount;
        }

        private double CalculateCartItemTotal(Models.CartItems items)
        {
            return CalculateCartItemTax(items) + (items.Amount * items.Good.Price);
        }

        private double CalculateTotalTaxAllGood()
        {
            double totalTax = 0.0;
            foreach(var item in cart.Goods)
            {
                totalTax += CalculateCartItemTax(item);
            }
            return totalTax;
        }

        private double CalculateTotalCostAllGood()
        {
            double totalTax = 0.0;
            foreach (var item in cart.Goods)
            {
                totalTax += CalculateCartItemTotal(item);
            }
            return totalTax;
        }

        private string CalculateEachCost()
        {
            string result = "";
            foreach (var items in cart.Goods)
            {
                result += "*"+items.Amount+" " + items.Good.Name + ": " + Formatter.FormatDouble(CalculateCartItemTotal(items)) + "\n";
            }
            return result;
        }

        public string GenerateRecipt()
        {
            string totalTax = Formatter.FormatDouble(CalculateTotalTaxAllGood());
            string totalCost = Formatter.FormatDouble(CalculateTotalCostAllGood());
            return CalculateEachCost() + "*Sales Tax: " + totalTax + " Total: " + totalCost;
        }
    }
}
