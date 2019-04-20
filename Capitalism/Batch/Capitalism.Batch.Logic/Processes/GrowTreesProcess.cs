using Capitalism.Infrastructure.Repositories;
using Capitalism.Logic.Models.Buildings;
using System;
using System.Collections.Generic;

namespace Capitalism.Batch.Logic.Processes
{
    public class GrowTreesProcess
    {
        private ITownBuildingRepository _townBuildingRepository;
        public GrowTreesProcess(ITownBuildingRepository townBuildingRepository)
        {
            _townBuildingRepository = townBuildingRepository;
        }

        public void Execute()
        {
            var random = new Random();
            IEnumerable<Forest> forests = _townBuildingRepository.GetByBuildingType<Forest>(typeof(Forest));
            foreach (var forest in forests)
            {
                var roll = random.Next(1, 100);

                // 20% chance of new growth in the forest
                if (roll <= 20) 
                {
                    forest.IncreaseTreeCount(1);
                    _townBuildingRepository.Update(forest);
                }

            }
        }
    }
}
