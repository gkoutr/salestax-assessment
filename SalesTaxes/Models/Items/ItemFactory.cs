using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SalesTaxes.Models
{
    /// <summary>
    /// Factory Pattern which will determine which object to return back to the client.
    /// These objects include TaxFreeItems and BasicTaxItems. Import tax can apply to both.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// List that holds some hardcoded tax free items to check against. 
        /// </summary>
        static readonly List<String> TaxFreeItemsList = new List<String>()
        {
            "pills",
            "bananas",
            "chocolate",
            "medical",
            "book",
            "books",
            "food",
            "banana",
            "medicine",
            "chocolates",
            "bar",
            "chocolate bar"
        };

        /// <summary>
        /// Determines what object to return back to the client. This hides the object creation
        /// so the only thing the client needs to do is pass the attributes for the item.
        /// This method checks if the item is imported by checking the name.
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="quantity">Item quantity</param>
        /// <param name="price">Price of the item</param>
        /// <returns></returns>
        public static Item BuildItem(String name, int quantity, decimal price)
        {
            bool isImported = name.ToLower().Contains("imported");
            if (TaxFreeItemsList.Any(x => name.ToLower().Contains(x)))
            {
                return new TaxFreeItem(name, quantity, price, isImported);
            }
            else
            {
                return new BasicTaxItem(name, quantity, price, isImported);
            }
        }
    }
}
