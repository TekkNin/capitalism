using Capitalism.Infrastructure.Dtos;
using Capitalism.Logic.Models;
using Capitalism.Logic.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Capitalism.Infrastructure.Repositories
{
    public class TownRepository : ITownRepository
    {
        private readonly IDataAccessConfiguration _configuration;
        public TownRepository(IDataAccessConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void Add(Town town)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var townDto = town.ToTownDto();
                db.Insert<TownDto>(townDto);
            }
        }

        public Town Get(string id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                return db.Get<TownDto>(id).ToTown();
            }
        }

        public Town GetSmallestTown()
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                var townDto = db.Query<TownDto>("SELECT * FROM [Towns] WHERE [Population] = (SELECT MIN([Population]) FROM [Towns])").First();
                return townDto.ToTown();
            }
        }

        public void Update(Town town)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                db.Update<TownDto>(town.ToTownDto());
            }
        }
    }
}
