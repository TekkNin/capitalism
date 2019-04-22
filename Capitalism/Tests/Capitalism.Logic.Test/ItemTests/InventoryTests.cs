using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Capitalism.Logic.Test.ItemTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void Add_Item_To_Inventory_Should_Increase_Quanityt()
        {
            var inventory = new Inventory();
            inventory.AddItem(new InventoryItem(1, new BasicBuildingMaterial()));
            inventory.AddItem(new InventoryItem(1, new BasicBuildingMaterial()));

            Assert.AreEqual(2, inventory.Items.First(x => x.ItemType.Name == new BasicBuildingMaterial().Name).Quantity);
        }

        [TestMethod]
        public void Add_Item_To_Inventory_Should_Increase_Quanity_Option2()
        {
            var inventory = new Inventory();
            inventory.AddItem(new InventoryItem(1, new BasicBuildingMaterial()));
            inventory.AddItem(1, new BasicBuildingMaterial());

            Assert.AreEqual(2, inventory.Items.First(x => x.ItemType.Name == new BasicBuildingMaterial().Name).Quantity);
        }

        [TestMethod]
        public void Remove_Item_To_Inventory_Should_Decrease_Quanity()
        {
            var inventory = new Inventory();
            inventory.AddItem(new InventoryItem(5, new BasicBuildingMaterial()));
            inventory.RemoveItems(new InventoryItem(2, new BasicBuildingMaterial()));

            Assert.AreEqual(3, inventory.Items.First(x => x.ItemType.Name == new BasicBuildingMaterial().Name).Quantity);
        }

        [TestMethod]
        public void Remove_Item_To_Inventory_Should_Decrease_Quanity_Option2()
        {
            var inventory = new Inventory();
            inventory.AddItem(new InventoryItem(5, new BasicBuildingMaterial()));
            inventory.RemoveItems(2, new BasicBuildingMaterial());

            Assert.AreEqual(3, inventory.Items.First(x => x.ItemType.Name == new BasicBuildingMaterial().Name).Quantity);
        }
    }
}
