using Capitalism.Logic.Repositories;

namespace Capitalism.Batch.Logic.Processes
{
    public class IncreaseEnergyProcess
    {
        private readonly IPlayerRepository _playerRepository;
        public IncreaseEnergyProcess(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute()
        {
            var players = _playerRepository.GetAll();
            foreach (var player in players)
            {
                if (!player.IsAlive)
                    continue;

                player.AddEnergy(1);
                _playerRepository.UpdateStats(player);
            }
        }
    }
}
