using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Handlers
{
    public class TransferBuildingOwnershipHandler : IHandle<BuildingPurchasedEvent>
    {
        private IPlayerRepository _playerRepository;
        private ITownRepository _townRepository;
        private ITownBuildingRepository _townBuildingRepository;

        public TransferBuildingOwnershipHandler(IPlayerRepository playerRepository, ITownRepository townRepository, ITownBuildingRepository townBuildingRepository)
        {
            _playerRepository = playerRepository;
            _townRepository = townRepository;
            _townBuildingRepository = townBuildingRepository;
        }

        public void Handle(BuildingPurchasedEvent domainEvent)
        {
            // The building has now owner, so it is being sold by the town
            if (String.IsNullOrEmpty(domainEvent.Building.OwnerId))
            {
                var town = _townRepository.Get(domainEvent.Building.TownId);
                town.IncreaseAccountBalance((int)domainEvent.Building.Price);
                _townRepository.Update(town);
            }
            // The building has an owner who should be paid for the sale
            else
            {
                var previousOwner = _playerRepository.Get(domainEvent.Building.OwnerId);
                previousOwner.EarnMoney((int)domainEvent.Building.Price);
                _playerRepository.UpdateStats(previousOwner);
            }
            
            domainEvent.PurchasingPlayer.SpendMoney((int)domainEvent.Building.Price);
            domainEvent.Building.SetOwner(domainEvent.PurchasingPlayer.Id);
            
            _playerRepository.UpdateStats(domainEvent.PurchasingPlayer);
            _townBuildingRepository.Update(domainEvent.Building);
        }
    }
}
