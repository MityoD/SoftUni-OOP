using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void ItemCtor()
        {
            Item item = new Item("Alex", "ItemID");
            Assert.AreEqual("Alex", item.Owner);
            Assert.AreEqual("ItemID", item.ItemId);
        }

        [Test]
        public void BankVaultCtor()
        {
            Assert.AreEqual(12, bankVault.VaultCells.Count);

            Assert.IsNotNull(bankVault.VaultCells);
        }


        [Test]
        public void BankVaultAddItemExceptionForCell()
        {
            string cell = "D5";
            Item item = new Item("Alex", "ItemID");


            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item));
        }

        [Test]
        public void BankVaultAddItemExceptionForCellNotNull()
        {
            string cell = "A1";
            Item item = new Item("Alex", "ItemID");
            Item item2 = new Item("Alex2", "ItemID2");
            bankVault.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item2));
        }

        [Test]
        public void BankVaultAddItemExceptionForCellExist()
        {
            string cell1 = "A1";
            string cell2 = "A2";
            Item item1 = new Item("Alex", "ItemID");
            Item item2 = new Item("Alex2", "ItemID");
            bankVault.AddItem(cell1, item1);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(cell2, item2));
        }
        //$"Item:{item.ItemId} saved successfully!";

        [Test]
        public void BankVaultAddItemReturnString()
        {
            string cell1 = "A1";
            //string cell2 = "A2";
            Item item1 = new Item("Alex", "ItemID");
            //Item item2 = new Item("Alex2", "ItemID");          

            string result = $"Item:{item1.ItemId} saved successfully!";

            Assert.AreEqual(result, bankVault.AddItem(cell1, item1).ToString());
            Assert.AreEqual(bankVault.VaultCells["A1"], item1);
        }

        /* if (!this.vaultCells.ContainsKey(cell))
        {
            throw new ArgumentException("Cell doesn't exists!");
        }*/

        [Test]
        public void BankVaultRemoveThrowsExceptionForUnexistingCell()
        {
            string cell = "A7";
            Item item = new Item("Alex", "ItemID");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item));            
        }

        [Test]
        public void BankVaultRemoveThrowsExceptionForUnexistingItem()
        {
            string cell = "A1";
            Item item = new Item("Alex", "ItemID");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item));
        }

        //$"Remove item:{item.ItemId} successfully!";

        [Test]
        public void BankVaultRemoveItem()
        {
            string cell = "A1";
            Item item = new Item("Alex", "ItemID");
            bankVault.AddItem(cell, item);

            Assert.AreEqual(item, bankVault.VaultCells[cell]);
            string result = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(result, bankVault.RemoveItem(cell, item).ToString());
            Assert.IsNull(bankVault.VaultCells[cell]);


        }
    }
}