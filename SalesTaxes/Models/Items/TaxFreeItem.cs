using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class TaxFreeItem : Item
    {
        public TaxFreeItem(String name, int quantity, decimal price, bool isImported) : base(name, quantity, price, isImported)
        {

        }

        /// <summary>
        /// If the item is imported, it will add a 5% sales tax, or else no sales tax will be applied.
        /// </summary>
        public override decimal Tax
        {
            get
            {
                var importedTax = IsImported ? Math.Ceiling((Price * .05M) * 20) / 20 : 0;
                return importedTax * Quantity; 
            }
        }
    }
}
