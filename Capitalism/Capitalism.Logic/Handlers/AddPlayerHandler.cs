using Capitalism.Logic.Events;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;

namespace Capitalism.Logic.Handlers
{
    public class AddPlayerHandler : IHandle<PlayerCreatedEvent>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITownRepository _townRepository;
        public AddPlayerHandler(IPlayerRepository playerRepository, ITownRepository townRepository)
        {
            _playerRepository = playerRepository;
            _townRepository = townRepository;
        }

        public void Handle(PlayerCreatedEvent domainEvent)
        {
            var town = _townRepository.GetSmallestTown();
            town.AddCitizen();
            _townRepository.Update(town);

            domainEvent.Player.SetTown(town.Id);
            _playerRepository.Add(domainEvent.Player);
        }
    }
}
