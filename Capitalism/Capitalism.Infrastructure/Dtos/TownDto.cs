using System;
using Capitalism.Logic.Models;
using Dapper.Contrib.Extensions;

namespace Capitalism.Infrastructure.Dtos
{
    [Table("Towns")]
    public class TownDto
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public long AccountBalance { get; set; }
        public int PollutionLevel { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Town ToTown()
        {
            return new Town(
                this.Id,
                this.Name,
                this.Population,
                this.AccountBalance,
                this.PollutionLevel,
                this.ModifiedDate,
                this.CreatedDate);
        }
    }

    public static class TownExtension
    {
        public static TownDto ToTownDto(this Town town)
        {
            return new TownDto
            {
                Id = town.Id,
                Name = town.Name,
                Population = town.Population,
                AccountBalance = town.AccountBalance,
                PollutionLevel = town.PollutionLevel,
                ModifiedDate = town.ModifiedDate,
                CreatedDate = town.CreatedDate
            };
        }
    }
}
