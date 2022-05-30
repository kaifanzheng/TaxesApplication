using System;
using TaxApp.Models;

namespace TaxApp.Services
{
    public class Formatter
    {
        public static string FormatDouble(double num)
        {
            return string.Format("{0:0.00}", num);
        }
    }
}
