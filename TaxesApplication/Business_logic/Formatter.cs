using System;
namespace TaxesApplication.Business_logic
{
    public class Formatter
    {
        public static string FormatDouble(double num)
        {
            return string.Format("{0:0.00}", num);
        }
    }
}
