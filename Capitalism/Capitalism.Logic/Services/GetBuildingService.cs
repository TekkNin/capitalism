using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Capitalism.Logic.Services
{
    public class GetBuildingService
    {
        private readonly ITownBuildingRepository _townBuildingRepository;
        public GetBuildingService(ITownBuildingRepository townBuildingRepository)
        {
            _townBuildingRepository = townBuildingRepository;
        }

        public IMappable GetBuildingByTownIdBuildingId(string townId, string buildlingId)
        {
            return _townBuildingRepository.GetByTownIdBuildingId(townId, buildlingId);
        }

        public IEnumerable<IMappable> GetByTownId(string townId)
        {
            return _townBuildingRepository.GetByTown(townId).ToList().OrderBy(x => x.YCoordinate).ThenBy(x => x.XCoordinate);
        }
    }
}
