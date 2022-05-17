using System;
namespace TaxesApplication.Models
{
    //enum class to determine the type of goods. how much tax to pay
    public enum GoodType
    {
        Undefined = 0,
        regular = 1,
        taxFree = 2,
        importedRegular = 3,
        importedTaxFree = 4

    }
}
