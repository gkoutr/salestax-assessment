using SalesTaxes.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// This SalesTax program takes in user input in a certain format (ex: 1 Book at 12.49), then will calculate the tax for the items and output the
/// items in a list with the total price and total taxes. This application uses a Factory pattern to determine which object to return 
/// back to the client. The object is determined by the Name of the Item, since the name determines if it's imported, taxable or non taxable
/// </summary>
namespace SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int itemCount;
            String[] seperator = {
                " at ",
            };
            Console.WriteLine("How many items are in your Shopping Cart? ");
            line = Console.ReadLine();
            itemCount = Convert.ToInt32(line);
            List<Item> items = new List<Item>();
            Console.WriteLine("Enter input in the following format: 1 Book at 12.49");
            ///Loop through items and take console input
            for (var x = 0; x < itemCount; x++){
                String[] input;
                //Split input into a String[] in order to gather quantity, name and price                
                input = Console.ReadLine().Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                int quantity = Convert.ToInt32(input[0].Substring(0, 1));
                String name = input[0].Substring(2);
                decimal price = Convert.ToDecimal(input[1]);
                items.Add(ItemFactory.BuildItem(name, quantity, price));
            }

            //Print the Receipt
            Receipt receipt = new Receipt(items);
            receipt.PrintReceipt();
            Console.WriteLine("Press any key to close");
            line = Console.ReadLine();
        }

    }
}
