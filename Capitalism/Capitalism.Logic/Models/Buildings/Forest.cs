using Capitalism.Logic.Events;
using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Models.Items;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;

namespace Capitalism.Logic.Models.Buildings
{
    /// <summary>
    /// The forest is a goverment controlled building type that allows players to get basic construction materials, but with a lot of effort. 
    /// This allows players to start constructing other types of buildings without any skills
    /// </summary>
    public class Forest : WritableEntity, IMappable, IWorkable
    {
        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name => "Forest";

        public int TreesRemaining { get; private set; }
        public int EnergyRequirement => 10;
        public int Wage => 0;

        public WorkResult Work(Player player)
        {
            if (!player.IsAlive)
                return WorkResult.Failed("You're dead.");
            if (this.TreesRemaining == 0)
                return WorkResult.Failed("All the mature trees are gone. Wait for them to grow.");
            if (player.Energy < this.EnergyRequirement)
                return WorkResult.Failed("You don't have enough energy to work in the forest.");

            var workResult = WorkResult.Success;
            player.ReduceEnergy(this.EnergyRequirement);
            player.EarnMoney(this.Wage);

            player.Inventory.AddItem(1, new ConstuctionMaterial());
            this.TreesRemaining--;

            CheckForInjury(player, workResult);           

            DomainEvents.Raise(new PlayerWorkedEvent(player, this));            
            DomainEvents.Raise(new ForestWorkedEvent(this));

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
