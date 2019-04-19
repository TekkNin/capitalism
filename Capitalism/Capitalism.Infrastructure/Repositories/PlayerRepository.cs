using Capitalism.Infrastructure.Dtos;
using Capitalism.Logic.Models;
using Capitalism.Logic.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Capitalism.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDataAccessConfiguration _configuration;
        public PlayerRepository(IDataAccessConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(Player player)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var playerDto = player.ToPlayerDto();
                db.Insert<PlayerDto>(playerDto);
            }
        }

        public IEnumerable<Player> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var playerDtos = db.GetAll<PlayerDto>();
                return playerDtos.Select(x => x.ToPlayer());
            }
        }

        public Player Get(string id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var player = db.Get<PlayerDto>(id).ToPlayer();

                PopulateInventory(db, player);

                return player;
            }
        }

        public Player GetByUserId(string userId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var playerDto = db.Query<PlayerDto>("SELECT * FROM [Players] WHERE UserId = @UserId", new { userId }).SingleOrDefault();
                var player = playerDto?.ToPlayer();

                PopulateInventory(db, player);

                return player;
            }
        }

        public void UpdateStats(Player player)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                db.Update<PlayerDto>(player.ToPlayerDto());
            }
        }

        public void Update(Player player)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                db.Update<PlayerDto>(player.ToPlayerDto());

                // Check if the inventory has changed and update it
                var inventoryItemDtoList = db.Query<InventoryItemDto>("SELECT * FROM [PlayerInventory] WHERE PlayerId = @PlayerId", new { PlayerId = player.Id }).ToList();
                foreach (var inventoryItem in player.Inventory?.Items == null ? new List<InventoryItem>() : player.Inventory.Items)
                {
                    if (inventoryItemDtoList.Any(x => inventoryItem.ItemType.GetType().Name == x.ItemType) &&
                        inventoryItemDtoList.First(x => inventoryItem.ItemType.GetType().Name == x.ItemType).Quantity != inventoryItem.Quantity)
                    {
                        db.Update<InventoryItemDto>(inventoryItem.ToInventoryItemDto(player.Id));
                    }
                    else if (!inventoryItemDtoList.Any(x => inventoryItem.ItemType.GetType().Name == x.ItemType))
                    {
                        db.Insert<InventoryItemDto>(inventoryItem.ToInventoryItemDto(player.Id));
                    }
                }
            }
        }

        public void UpdateTown(Player player, string townId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                db.ExecuteScalar("UPDATE [Players] SET [TownId] = @TownId WHERE [Id] = @PlayerId", new { TownId = townId, PlayerId = player.Id });
            }
        }

        private static void PopulateInventory(IDbConnection db, Player player)
        {
            if (player == null)
                return;

            var inventoryItemDtoList = db.Query<InventoryItemDto>("SELECT * FROM [PlayerInventory] WHERE PlayerId = @PlayerId", new { PlayerId = player.Id }).ToList();
            foreach (var inventoryItemDto in inventoryItemDtoList)
            {
                player.Inventory.AddItem(inventoryItemDto.ToInventoryItem());
            }
        }

    }
}
