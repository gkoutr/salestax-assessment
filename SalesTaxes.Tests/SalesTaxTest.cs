using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxes.Models;
using System.Collections.Generic;

namespace SalesTaxes.Tests
{
    [TestClass]
    public class SalesTaxTest
    {
        private readonly List<Item> items;
        private Receipt receipt;

        public SalesTaxTest()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// Test the first use case in the assignment. Verify the correct object was created by the Factory, and then verify the correct tax and price.
        /// #1: 1 Book at 12.49
        /// #2: 1 Book at 12.49
        /// #3: 1 Music CD at 14.99
        /// #4: 1 Chocolate bar at 0.85
        /// </summary>
        [TestMethod]
        public void Test_Receipt_With_Items_Case_1()
        {
            Item book1 = ItemFactory.BuildItem("Book", 1, 12.49M);
            Assert.IsInstanceOfType(book1, typeof(TaxFreeItem));
            Assert.AreEqual(book1.Tax, 0);
            Assert.AreEqual(book1.TotalPrice, 12.49M);
            items.Add(book1);

            Item book2 = ItemFactory.BuildItem("Book", 1, 12.49M);
            Assert.IsInstanceOfType(book2, typeof(TaxFreeItem));
            Assert.AreEqual(book2.Tax, 0);
            Assert.AreEqual(book2.TotalPrice, 12.49M);
            items.Add(book2);

            Item cd = ItemFactory.BuildItem("Music CD", 1, 14.99M);
            Assert.IsInstanceOfType(cd, typeof(BasicTaxItem));
            Assert.AreEqual(cd.Tax, 1.50M);
            Assert.AreEqual(cd.TotalPrice, 16.49M);
            items.Add(cd);

            Item chocolateBar = ItemFactory.BuildItem("Chocolate bar", 1, 0.85M);
            Assert.IsInstanceOfType(chocolateBar, typeof(TaxFreeItem));
            Assert.AreEqual(chocolateBar.Tax, 0);
            Assert.AreEqual(chocolateBar.TotalPrice, 0.85M);
            items.Add(chocolateBar);

            receipt = new Receipt(items);
            Assert.AreEqual(receipt.TotalTaxes, 1.50M);
            Assert.AreEqual(receipt.TotalPrice, 42.32M);
        }

        /// <summary>
        /// Test the second use case in the assignment. Verify the correct object was created by the Factory, and then verify the correct tax and price.
        /// #1: 1 Imported box of chocolates at 10.00
        /// #2: 1 Imported bottle of perfume at 47.50 
        /// </summary>
        [TestMethod]
        public void Test_Receipt_With_Imported_Items_Case_2()
        {
            Item importedChocolates = ItemFactory.BuildItem("Imported box of chocolates", 1, 10.00M);
            Assert.IsInstanceOfType(importedChocolates, typeof(TaxFreeItem));
            Assert.AreEqual(importedChocolates.Tax, .50M);
            Assert.AreEqual(importedChocolates.TotalPrice, 10.50M);
            items.Add(importedChocolates);

            Item importedPerfume = ItemFactory.BuildItem("Imported bottle of perfume", 1, 47.50M);
            Assert.IsInstanceOfType(importedPerfume, typeof(BasicTaxItem));
            Assert.AreEqual(importedPerfume.Tax, 7.15M);
            Assert.AreEqual(importedPerfume.TotalPrice, 54.65M);
            items.Add(importedPerfume);

            receipt = new Receipt(items);
            Assert.AreEqual(receipt.TotalTaxes, 7.65M);
            Assert.AreEqual(receipt.TotalPrice, 65.15M);
        }

        /// <summary>
        /// Test the third use case in the assignment. Verify the correct object was created by the Factory, and then verify the correct tax and price.
        /// #1: 1 Imported bottle of perfume at 27.99
        /// #2: 1 Bottle of perfume at 18.99
        /// #3: 1 Packet of headache pills at 9.75
        /// #4: 1 Imported box of chocolates at 11.25
        /// #5: 1 Imported box of chocolates at 11.25
        /// </summary>
        [TestMethod]
        public void Test_Receipt_With_Items_Case_3()
        {
          
            Item importedPerfume = ItemFactory.BuildItem("Imported bottle of perfume", 1, 27.99M);
            Assert.IsInstanceOfType(importedPerfume, typeof(BasicTaxItem));
            Assert.AreEqual(importedPerfume.Tax, 4.20M);
            Assert.AreEqual(importedPerfume.TotalPrice, 32.19M);
            items.Add(importedPerfume);

            Item bottleOfPerfume = ItemFactory.BuildItem("Bottle of perfume", 1, 18.99M);
            Assert.IsInstanceOfType(bottleOfPerfume, typeof(BasicTaxItem));
            Assert.AreEqual(bottleOfPerfume.Tax, 1.90M);
            Assert.AreEqual(bottleOfPerfume.TotalPrice, 20.89M);
            items.Add(bottleOfPerfume);

            Item headachePills = ItemFactory.BuildItem("Packet of headache pills", 1, 9.75M);
            Assert.IsInstanceOfType(headachePills, typeof(TaxFreeItem));
            Assert.AreEqual(headachePills.Tax, 0M);
            Assert.AreEqual(headachePills.TotalPrice, 9.75M);
            items.Add(headachePills);

            Item importedChocolatesOne = ItemFactory.BuildItem("Imported box of chocolates", 1, 11.25M);
            Assert.IsInstanceOfType(importedChocolatesOne, typeof(TaxFreeItem));
            Assert.AreEqual(importedChocolatesOne.Tax, 0.60M);
            Assert.AreEqual(importedChocolatesOne.TotalPrice, 11.85M);
            items.Add(importedChocolatesOne);

            Item importedChocolatesTwo = ItemFactory.BuildItem("Imported box of chocolates", 1, 11.25M);
            Assert.IsInstanceOfType(importedChocolatesTwo, typeof(TaxFreeItem));
            Assert.AreEqual(importedChocolatesTwo.Tax, 0.60M);
            Assert.AreEqual(importedChocolatesTwo.TotalPrice, 11.85M);
            items.Add(importedChocolatesTwo);

            receipt = new Receipt(items);
            Assert.AreEqual(receipt.TotalTaxes, 7.30M);
            Assert.AreEqual(receipt.TotalPrice, 86.53M);
        }
    }
}
