using System;
using TaxesApplication.Business_logic;
using TaxesApplication.Models;

namespace TaxesApplication.Services
{
    public class ApplicationUser_service
    {
        private readonly IValidation validation;
        private readonly IClassification classification;
        public ApplicationUser_service(IValidation validation, IClassification classification)
        {
            this.validation = Argument.NotNull(validation, nameof(validation));
            this.classification = classification;
        }
        //create User
        public ApplicationUser CreateUser(string userID)
        {
            return new ApplicationUser(userID);
        }
        //add goods to the cart
        public void AddToCart(ApplicationUser aUser, Good aGood)
        {
            aUser.AddToCart(this.validation.IsGoodValid(aGood));
        }
        //private method to calculate the tax of one good
        private double CalculateTaxOneGood(Good good)
        {
            ICalculation calculation = this.classification.CreateCalculation(good);
            return calculation.CalculateTax();
        }
        //private method to calculate the total cost of one good
        private double CalculateToalCostOneGood(Good good)
        {
            return this.CalculateTaxOneGood(good) + good.GetPrice();
        }
        //private method calculate total tax of all good
        private double CalculateToalTaxAllGood(ApplicationUser user)
        {
            double result = 0.0;
            foreach (var good in user.GetCart())
            {
                result += CalculateTaxOneGood((Good)good);
            }
            return result;
        }
        //private method calculate total cost of all good\
        private double CalculateToalCostAllGood(ApplicationUser user)
        {
            double result = 0.0;
            foreach (var good in user.GetCart())
            {
                result += CalculateToalCostOneGood((Good)good);
            }
            return result;
        }
        //calculate the cost of each good and return a string
        private string CalculateEachCost(ApplicationUser user)
        {
            string result = "";
            foreach (var good in user.GetCart())
            {
                result += "*1 "+((Good)good).GetName() + ": " + Formatter.FormatDouble(CalculateToalCostOneGood((Good)good))+"\n";
            }
            return result;
        }
        //generate the recipt
        public string GenerateRecipt(ApplicationUser user)
        {
            string totalTax = Formatter.FormatDouble(CalculateToalTaxAllGood(user));
            string totalCost = Formatter.FormatDouble(CalculateToalCostAllGood(user));
            return CalculateEachCost(user) + "*Sales Tax: " + totalTax + " Total: " + totalCost;
        }
    }
}