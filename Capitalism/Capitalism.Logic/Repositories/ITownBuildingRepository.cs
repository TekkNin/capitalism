using Capitalism.Logic.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Capitalism.Infrastructure.Repositories
{
    public interface ITownBuildingRepository
    {
        IEnumerable<IMappable> GetByTown(string townId);
        IMappable GetByTownIdBuildingId(string townId, string buildingId);
        IEnumerable<T> GetByBuildingType<T>(Type type);
        void Update(IMappable building);
    }
}
