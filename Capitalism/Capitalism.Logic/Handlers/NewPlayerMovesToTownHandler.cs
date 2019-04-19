using Capitalism.Logic.Events;
using Capitalism.Logic.Repositories;
using Capitalism.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitalism.Logic.Handlers
{
    public class NewPlayerMovesToTownHandler : IHandle<PlayerCreatedEvent>
    {
        private readonly ITownRepository _townRepository;
        private readonly IPlayerRepository _playerRepository;
        public NewPlayerMovesToTownHandler(ITownRepository townRepository, IPlayerRepository playerRepository)
        {
            _townRepository = townRepository;
            _playerRepository = playerRepository;
        }

        public void Handle(PlayerCreatedEvent domainEvent)
        {
            var town = _townRepository.GetSmallestTown();
            town.AddCitizen();
            _townRepository.Update(town);

            _playerRepository.UpdateTown(domainEvent.Player, town.Id);
        }
    }
}
