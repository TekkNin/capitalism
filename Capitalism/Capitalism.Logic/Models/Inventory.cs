using Capitalism.Logic.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capitalism.Logic.Models
{
    /// <summary>
    /// Items that a player has on-hand. These items can be lost or stolen
    /// </summary>
    public class Inventory
    {
        public IEnumerable<InventoryItem> Items { get; private set; }

        public Inventory()
        {
            this.Items = new List<InventoryItem>();
        }

        public void AddItem<TItemCollectable>(int quantity, TItemCollectable item) where TItemCollectable :IItemCollectable
        {
            if (!this.Items.Any(x => x.ItemType.GetType() == typeof(TItemCollectable)))
            {
                var inventoryItem = new InventoryItem(quantity, item);
                ((List<InventoryItem>)this.Items).Add(inventoryItem);
            }
            else
            {
                this.Items.First(x => x.ItemType.GetType() == typeof(TItemCollectable)).IncreaseQuantity(quantity);
            }
        }

        public void AddItem(InventoryItem inventoryItem)
        {
            ((List<InventoryItem>)this.Items).Add(inventoryItem);
        }
    }

    public class InventoryItem
    {
        public int Quantity { get; private set; }
        public IItemCollectable ItemType { get; private set; }

        public InventoryItem(int quantity, IItemCollectable item)
        {
            this.Quantity = quantity;
            this.ItemType = item;
        }

        /// <summary>
        /// Increases the quantity for this particular item in the inventory. If a negative is specific the absolute value with be used.
        /// </summary>
        /// <param name="quantity"></param>
        public void IncreaseQuantity(int quantity)
        {
            this.Quantity += Math.Abs(quantity);
        }
    }
}
