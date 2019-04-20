using Capitalism.Logic.Models;
using Dapper.Contrib.Extensions;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("PlayerInventory")]
    public class PlayerInventoryItemDto
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

    public static class PlayerInventoryItemExtension
    {
        public static PlayerInventoryItemDto ToPlayerInventoryItemDto(this InventoryItem inventoryItem, string playerId)
        {
            return new PlayerInventoryItemDto
            {
                PlayerId = playerId,
                ItemType = inventoryItem.ItemType.GetType().Name,
                Quantity = inventoryItem.Quantity
            };
        }
    }
}
