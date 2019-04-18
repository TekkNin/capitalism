using Capitalism.Logic.Events;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;

namespace Capitalism.Logic.Handlers
{
    public class AddPlayerHandler : IHandle<PlayerCreatedEvent>
    {
        private readonly IPlayerRepository _playerRepository;
        public AddPlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Handle(PlayerCreatedEvent domainEvent)
        {
            _playerRepository.Add(domainEvent.Player);
        }
    }
}
