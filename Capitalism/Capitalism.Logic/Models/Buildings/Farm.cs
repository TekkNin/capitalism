using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.Logic.Models.Items;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capitalism.Logic.Models.Buildings
{
    public class Farm : WritableEntity, IMappable, IOwnable, IWorkable, IBuildable
    {
        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Image => "tractor";
        public string Name { get; private set; }

        public int EnergyRequirement => 10;
        public int Wage { get; private set; }
        public string OwnerId { get; private set; }
        public bool IsForSale { get; private set; }
        public int? Price { get; private set; }

        public Farm(string id, string townId, int xCoordinate, int yCoordinate, string name, string ownerId, bool isForSale, int? price, DateTime modifiedDate, DateTime createdDate) : 
            base(id, modifiedDate, createdDate)
        {
            TownId = townId;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            OwnerId = ownerId;
            IsForSale = isForSale;
            Price = price;
        }

        public IEnumerable<InventoryItem> BuildMaterials
        {
            get
            {
                return new List<InventoryItem>
                {
                    new InventoryItem(20, new BasicBuildingMaterial())
                };
            }
        }

        public ActionResults Build(EmptyLand emptyLand, Player player)
        {
            if (emptyLand.OwnerId != player.Id)
                return ActionResults.Failed("You do not own this building.");

            // Check for materials
            var results = ActionResults.Empty;
            foreach (var buildMaterial in this.BuildMaterials)
            {
                var playerItem = player.Inventory.Items.FirstOrDefault(item => item.ItemType.GetType() == buildMaterial.ItemType.GetType());
                if (playerItem == null || playerItem.Quantity < buildMaterial.Quantity)
                    results.AddResult(ActionResult.Failed($"You need {buildMaterial.Quantity} {buildMaterial.ItemType.Name} to build a farm."));
            }

            if (results.HasResults)
                return results;

            DomainEvents.Raise(new FarmBuiltEvent(player, this));
            return ActionResults.Success("You built a farm. Time to start planting.");
        }

        public void ChangeOwnership(string playerId)
        {
            this.OwnerId = playerId;
            this.IsForSale = false;
            this.Price = null;
            this.SetModifiedDate();
        }

        public ActionResults Purchase(Player purchasingPlayer)
        {
            throw new NotImplementedException();
        }

        public ActionResults Work(Player player)
        {
            throw new NotImplementedException();
        }

    }
}
