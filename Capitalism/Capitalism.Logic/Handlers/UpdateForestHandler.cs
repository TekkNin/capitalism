using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.SharedKernel.Events;

namespace Capitalism.Logic.Handlers
{
    public class UpdateForestHandler : IHandle<ForestWorkedEvent>
    {
        private readonly ITownBuildingRepository _townBuildingRepository;
        public UpdateForestHandler(ITownBuildingRepository townBuildingRepository)
        {
            _townBuildingRepository = townBuildingRepository;
        }

        public void Handle(ForestWorkedEvent domainEvent)
        {
            _townBuildingRepository.Update(domainEvent.Forest);
        }
    }
}
