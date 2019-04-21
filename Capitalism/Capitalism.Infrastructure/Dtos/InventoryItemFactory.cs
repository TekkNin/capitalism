using Capitalism.Logic.Models.Items;

namespace Capitalism.Infrastructure.Dtos
{
    public static class InventoryItemFactory
    {
        public static IItemCollectable ItemFromStringType(string itemType)
        {
            switch (itemType)
            {
                case nameof(BasicBuildingMaterial):
                    return new BasicBuildingMaterial();

            }

            return null;
        }
    }
}
