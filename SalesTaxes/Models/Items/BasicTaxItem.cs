using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class BasicTaxItem : Item
    {
        public BasicTaxItem(String name, int quantity, decimal price, bool isImported) : base(name, quantity, price, isImported)
        {

        }

        /// <summary>
        /// Calculates basic sales tax which is 10%. Uses Math.Ceiling to round the decimal value
        /// to the nearest 5 cents. If the item is imported, it will add a 5% sales tax as well.
        /// </summary>
        public override decimal Tax
        {
            get
            {
                var importedTax = IsImported ? Math.Ceiling((Price * .05M) * 20) / 20 : 0;
                var taxAmount = (importedTax + Math.Ceiling((Price * .10M) * 20) / 20) * Quantity;
                return Decimal.Parse(taxAmount.ToString("0.00"));
            }
        }
    }
}
