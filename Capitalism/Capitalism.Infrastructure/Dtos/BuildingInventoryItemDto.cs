using Capitalism.Logic.Models;
using Dapper.Contrib.Extensions;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("BuildingInventory")]
    public class BuildingInventoryItemDto
    {
        [ExplicitKey]
        public string BuildingId { get; set; }

        [ExplicitKey]
        public string ItemType { get; set; }

        public int Quantity { get; set; }

        public InventoryItem ToInventoryItem()
        {
            return new InventoryItem(this.Quantity, InventoryItemFactory.ItemFromStringType(this.ItemType));
        }
    }

    public static class BuildingInventoryItemExtension
    {
        public static BuildingInventoryItemDto ToBuildingInventoryItemDto(this InventoryItem inventoryItem, string buildingId)
        {
            return new BuildingInventoryItemDto
            {
                BuildingId = buildingId,
                ItemType = inventoryItem.ItemType.GetType().Name,
                Quantity = inventoryItem.Quantity
            };
        }
    }

}
