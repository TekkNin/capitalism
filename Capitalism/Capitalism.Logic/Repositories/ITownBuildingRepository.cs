using Capitalism.Logic.Models.Buildings;
using System.Collections.Generic;

namespace Capitalism.Infrastructure.Repositories
{
    public interface ITownBuildingRepository
    {
        IEnumerable<IMappable> GetByTown(string townId);
        IMappable GetByTownIdBuildingId(string townId, string buildingId);
    }
}
