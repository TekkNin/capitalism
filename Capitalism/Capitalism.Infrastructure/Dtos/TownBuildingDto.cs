using Capitalism.Logic.Models.Buildings;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.SharedKernel.Model;
using Dapper.Contrib.Extensions;
using System;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("TownBuildings")]
    public class TownBuildingDto
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string TownId { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string BuildingType { get; set; }

        // IOwnable Properties
        public string OwnerId { get; set; }
        public bool? IsForSale { get; set; }
        public int? Price { get; set; }

        // WritableEntity Properties
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public IMappable ToBuilding()
        {
            switch (this.BuildingType)
            {
                case nameof(TownHall):
                    return new TownHall(this.Id, this.TownId, this.XCoordinate, this.YCoordinate, this.ModifiedDate, this.CreatedDate);
                case nameof(Mine):
                    return new Mine(this.Id, this.TownId, this.XCoordinate, this.YCoordinate, this.ModifiedDate, this.CreatedDate);
                case nameof(Forest):
                    return new Forest(this.Id, this.TownId, this.XCoordinate, this.YCoordinate, this.ModifiedDate, this.CreatedDate);
                case nameof(EmptyLand):
                    return new EmptyLand(this.Id, this.TownId, this.XCoordinate, this.YCoordinate, this.Name, this.OwnerId, (bool)this.IsForSale, this.Price, this.ModifiedDate, this.CreatedDate);
            }

            return null;
        }
    }

    public static class BuildingExtension
    {
        public static TownBuildingDto ToTownBuildingDto(this IMappable building)
        {
            var buildingDto = new TownBuildingDto
            {
                Id = building.Id,
                TownId = building.TownId,
                XCoordinate = building.XCoordinate,
                YCoordinate = building.YCoordinate,
                Name = building.Name,
                BuildingType = building.GetType().Name
            };

            if (building is IOwnable)
            {
                buildingDto.OwnerId = ((IOwnable)building).OwnerId;
                buildingDto.IsForSale = ((IOwnable)building).IsForSale;
                buildingDto.Price = ((IOwnable)building).Price;
            }

            if (building is WritableEntity)
            {
                buildingDto.ModifiedDate = ((WritableEntity)building).ModifiedDate;
                buildingDto.CreatedDate = ((WritableEntity)building).CreatedDate;
            }

            return buildingDto;
        }
    }
}
