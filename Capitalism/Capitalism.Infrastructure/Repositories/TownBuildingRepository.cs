using Capitalism.Infrastructure.Dtos;
using Capitalism.Logic.Models;
using Capitalism.Logic.Models.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Capitalism.Infrastructure.Repositories
{
    public class TownBuildingRepository : ITownBuildingRepository
    {
        private readonly IDataAccessConfiguration _configuration;
        public TownBuildingRepository(IDataAccessConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<IMappable> GetByTown(string townId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var townBuildingDtos = db.Query<TownBuildingDto>("SELECT * FROM [TownBuildings] WHERE TownId = @TownId", new { townId }).ToList();
                return townBuildingDtos.Select(x => x.ToBuilding());
            }
        }

        public IMappable GetByTownIdBuildingId(string townId, string buildingId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var building = db.Query<TownBuildingDto>("SELECT * FROM [TownBuildings] WHERE TownId = @TownId AND Id = @BuildingId",
                    new { townId, buildingId }).Single().ToBuilding();

                if (building is IStorable)
                    PopulateInventory(db, (IStorable)building);

                return building;
            }
        }

        private static void PopulateInventory(IDbConnection db, IStorable building)
        {
            if (building == null)
                return;

            var inventoryItemDtoList = db.Query<BuildingInventoryItemDto>("SELECT * FROM [BuildingInventory] WHERE BuildingId = @BuildingId", new { BuildingId = building.Id }).ToList();
            foreach (var inventoryItemDto in inventoryItemDtoList)
            {
                building.Inventory.AddItem(inventoryItemDto.ToInventoryItem());
            }
        }

        public IEnumerable<T> GetByBuildingType<T>(Type type)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var buildingDtos = db.Query<TownBuildingDto>("SELECT * FROM [TownBuildings] WHERE BuildingType = @BuildingType", new { BuildingType = type.Name }).ToList();
                var buildings = buildingDtos.Select(x => (T)x.ToBuilding());

                var returnVal = new List<T>();
                foreach (var buildingDto in buildingDtos)
                {
                    var building = buildingDto.ToBuilding();
                    if (building is IStorable)
                        PopulateInventory(db, (IStorable)building);

                    returnVal.Add((T)building);
                }

                return returnVal;
            }
        }

        public void Update(IMappable building)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                db.Update<TownBuildingDto>(building.ToTownBuildingDto());

                if (building is IStorable)
                {
                    // Check if the inventory has changed and update it
                    var inventoryItemDtoList = db.Query<BuildingInventoryItemDto>("SELECT * FROM [BuildingInventory] WHERE BuildingId = @BuildingId", new { BuildingId = building.Id }).ToList();
                    foreach (var inventoryItem in ((IStorable)building).Inventory?.Items == null ? new List<InventoryItem>() : ((IStorable)building).Inventory.Items)
                    {
                        if (inventoryItemDtoList.Any(x => inventoryItem.ItemType.GetType().Name == x.ItemType) &&
                            inventoryItemDtoList.First(x => inventoryItem.ItemType.GetType().Name == x.ItemType).Quantity != inventoryItem.Quantity)
                        {
                            db.Update<BuildingInventoryItemDto>(inventoryItem.ToBuildingInventoryItemDto(building.Id));
                        }
                        else if (!inventoryItemDtoList.Any(x => inventoryItem.ItemType.GetType().Name == x.ItemType))
                        {
                            db.Insert<BuildingInventoryItemDto>(inventoryItem.ToBuildingInventoryItemDto(building.Id));
                        }
                    }
                }
            }
        }
    }
}
