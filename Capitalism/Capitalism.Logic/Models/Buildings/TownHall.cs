using System;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.SharedKernel.Model;

namespace Capitalism.Logic.Models.Buildings
{
    public class TownHall : WritableEntity, IMappable
    {
        public TownHall(string id, string townId, int xCoordinate, int yCoordinate, DateTime modifiedDate, DateTime createdDate) :
            base(id, modifiedDate, createdDate)
        {
            TownId = townId;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public string TownId { get; private set; }

        public int XCoordinate { get; private set; }

        public int YCoordinate { get; private set; }

        public string Image => "landmark";

        public string Name => "Town Hall";
    }
}
