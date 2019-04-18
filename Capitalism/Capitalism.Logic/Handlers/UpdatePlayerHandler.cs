using Capitalism.Logic.Events;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;

namespace Capitalism.Logic.Handlers
{
    public class UpdatePlayerHandler : IHandle<PlayerWorkedEvent>
    {
        private readonly IPlayerRepository _playerRepository;
        public UpdatePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Handle(PlayerWorkedEvent domainEvent)
        {
            _playerRepository.Update(domainEvent.Player);
        }
    }
}
