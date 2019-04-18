using Capitalism.Logic.Models;
using Capitalism.Logic.Repositories;

namespace Capitalism.Logic.Services
{
    public class GetPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public GetPlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player GetByUserId(string userId)
        {
            return _playerRepository.GetByUserId(userId);
        }
    }
}
