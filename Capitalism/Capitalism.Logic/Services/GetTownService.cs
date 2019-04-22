using Capitalism.Logic.Models;
using Capitalism.Logic.Repositories;

namespace Capitalism.Logic.Services
{
    public class GetTownService
    {
        private readonly ITownRepository _townRepository;
        public GetTownService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public Town GetById(string townId)
        {
            return _townRepository.Get(townId);
        }
    }
}
