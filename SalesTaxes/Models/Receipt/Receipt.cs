using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SalesTaxes.Models
{
    public class Receipt
    {
        private List<Item> _items { get; }
        public Receipt(List<Item> items)
        {
            _items = JoinList(items);
        }

        public decimal TotalTaxes { get => _items.Sum(x => x.Tax); }

        public decimal TotalPrice { get => _items.Sum(x => x.TotalPrice); }

        /// <summary>
        /// Join list of objects based on the name and increase quantity.
        /// </summary>
        private List<Item> JoinList(List<Item> _items)
        {
            for(var x = 1; x < _items.Count; x++)
            {
                if(_items[x].Name.Equals(_items[x - 1].Name))
                {
                    _items[x].Quantity++;
                    _items.Remove(_items[x - 1]);
                }
            }
            return _items;
        }

        public void PrintReceipt()
        {
            if(_items == null || _items.Count == 0)
            {
                Console.WriteLine("No items have been purchased");
                return;
            }

            foreach (var item in _items)
            { 
                Console.WriteLine("");
                bool HasMultipleItems = item.Quantity > 1;
                Console.Write("{0}: {1} ", item.Name, item.TotalPrice);
                Console.Write(HasMultipleItems ? "({0} @ {1})" : "", item.Quantity, item.Price + (item.Tax / item.Quantity));
            }
            Console.WriteLine("");
            Console.WriteLine("Sales Taxes: {0}", TotalTaxes);
            Console.WriteLine("Total: {0}", TotalPrice);
        }
    }
}
