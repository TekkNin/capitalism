using Capitalism.Logic.Events;
using Capitalism.Logic.Models.Items;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using System;

namespace Capitalism.Logic.Models.Buildings
{
    /// <summary>
    /// The forest is a goverment controlled building type that allows players to get basic construction materials, but with a lot of effort. 
    /// This allows players to start constructing other types of buildings without any skills
    /// </summary>
    public class Forest : IWorkable
    {
        public int EnergyRequirement => 10;
        public int Wage => 0;

        public WorkResult Work(Player player)
        {
            if (!player.IsAlive)
                return WorkResult.Failed("You're dead.");
            if (player.Energy < this.EnergyRequirement)
                return WorkResult.Failed("You don't have enough energy to work in the forest.");

            var workResult = WorkResult.Success;
            player.ReduceEnergy(this.EnergyRequirement);
            player.EarnMoney(this.Wage);

            player.Inventory.AddItem(1, new ConstuctionMaterial());

            CheckForInjury(player, workResult);

            DomainEvents.Raise<PlayerWorkedEvent>(new PlayerWorkedEvent(player, this));

            return workResult;
        }

        private static void CheckForInjury(Player player, WorkResult workResult)
        {
            var injuryRoll = new Random().Next(1, 100);

            // 1% chance of minor injury
            if (injuryRoll <= 1)
            {
                player.ReduceHealth(5);
                workResult.AddMessage("You had a minor injury in the forest.");
            }
            // 95% chance of no injury
            else
            {

            }
        }

    }
}
