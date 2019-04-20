using Capitalism.Logic.Models.Interfaces;
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

    }
}
