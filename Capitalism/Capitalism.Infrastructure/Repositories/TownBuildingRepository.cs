using Capitalism.Infrastructure.Dtos;
using Capitalism.Logic.Models.Buildings;
using Dapper;
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
                var townBuildingDto = db.Query<TownBuildingDto>("SELECT * FROM [TownBuildings] WHERE TownId = @TownId AND Id = @BuildingId", 
                    new { townId, buildingId }).Single();
                return townBuildingDto.ToBuilding();
            }
        }
    }
}
