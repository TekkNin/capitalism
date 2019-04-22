using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;

namespace Capitalism.Logic.Models.Buildings
{
    public class EmptyLand : WritableEntity, IMappable, IOwnable
    {
        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Image => "minus";
        public string Name { get; private set; }
        public string OwnerId { get; private set; }
        public bool IsForSale { get; private set; }
        public int? Price { get; private set; }

        public EmptyLand(string id, string townId, int xCoordinate, int yCoordinate, string name, string ownerId, bool isForSale, int? price, DateTime modifiedDate, DateTime createdDate) :
            base(id, modifiedDate, createdDate)
        {
            this.TownId = townId;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Name = name;
            this.OwnerId = ownerId;
            this.IsForSale = isForSale;
            this.Price = price;
        }

        public void SetOwner(string playerId) => this.OwnerId = playerId;

        public ActionResults Purchase(Player purchasingPlayer)
        {
            if (this.IsForSale)
                return ActionResults.Failed("This land is not for sale.");
            if (purchasingPlayer.CurrentTown != this.TownId)
                return ActionResults.Failed("You must be in the same town as the land to purchase it.");
            if (purchasingPlayer.MoneyOnHand < this.Price)
                return ActionResults.Failed("You do not have enough money to purchase this land.");

            DomainEvents.Raise<BuildingPurchasedEvent>(new BuildingPurchasedEvent(this, purchasingPlayer));
            return ActionResults.Success($"You've puchased the empty land for ${String.Format("{0:n0}", this.Price)}. Time to start building!");
        }
    }
}
