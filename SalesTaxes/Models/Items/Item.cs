using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    /// <summary>
    /// Abstract class with a abstract property Tax. This will be defined in the subclasses
    /// since taxes apply to different items.
    /// </summary>
    public abstract class Item
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public abstract decimal Tax { get; }
        public decimal TotalPrice { get {
                var totalPrice = (Price * Quantity);
                if (Tax == 0) return totalPrice;
                return totalPrice + Tax;
            }
        }

        protected Item(String name, int quantity, decimal price, bool isImported)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            IsImported = isImported;
        }
    }
}
