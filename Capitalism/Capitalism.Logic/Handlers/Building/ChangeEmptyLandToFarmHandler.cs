using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;

namespace Capitalism.Logic.Handlers.Building
{
    public class ChangeEmptyLandToFarmHandler : IHandle<FarmBuiltEvent>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITownBuildingRepository _townBuildingRepository;

        public ChangeEmptyLandToFarmHandler(IPlayerRepository playerRepository, ITownBuildingRepository townBuildingRepository)
        {
            _playerRepository = playerRepository;
            _townBuildingRepository = townBuildingRepository;
        }

        public void Handle(FarmBuiltEvent domainEvent)
        {
            foreach (var buildMaterial in domainEvent.Farm.BuildMaterials)
            {
                domainEvent.Player.Inventory.RemoveItems(buildMaterial.Quantity, buildMaterial.ItemType);
            }

            _playerRepository.Update(domainEvent.Player);
            _townBuildingRepository.Update(domainEvent.Farm);            
        }
    }
}
