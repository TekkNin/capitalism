using System;
using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Items;
using Dapper.Contrib.Extensions;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("PlayerInventory")]
    public class InventoryItemDto
    {
        [ExplicitKey]
        public string PlayerId { get; set; }

        [ExplicitKey]
        public string ItemType { get; set; }

        public int Quantity { get; set; }

        public InventoryItem ToInventoryItem()
        {
            return new InventoryItem(this.Quantity, InventoryItemFactory.ItemFromStringType(this.ItemType));
        }
    }

    public static class InventoryItemExtension
    {
        public static InventoryItemDto ToInventoryItemDto(this InventoryItem inventoryItem, string playerId)
        {
            return new InventoryItemDto
            {
                PlayerId = playerId,
                ItemType = inventoryItem.ItemType.GetType().Name,
                Quantity = inventoryItem.Quantity
            };
        }
    }

    public static class InventoryItemFactory
    {
        public static IItemCollectable ItemFromStringType(string itemType)
        {
            switch (itemType)
            {
                case nameof(ConstuctionMaterial):
                    return new ConstuctionMaterial();

            }

            return null;
        }
    }
}
