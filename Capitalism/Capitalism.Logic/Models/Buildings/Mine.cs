using Capitalism.Logic.Events;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;

namespace Capitalism.Logic.Models.Buildings
{
    /// <summary>
    /// The mine is a goverment controlled building type that allows players to get money, but with a lot of effort. 
    /// This also introduces new currency into the game and drives inflation.
    /// </summary>
    public class Mine : WritableEntity, IMappable, IWorkable
    {
        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name => "Mine";

        public int EnergyRequirement => 20;
        public int HappinessEffect => -5;
        public int Wage => 5;        

        public WorkResult Work(Player player)
        {
            if (!player.IsAlive)
                return WorkResult.Failed("You're dead.");
            if (player.Energy < this.EnergyRequirement)
                return WorkResult.Failed("You don't have enough energy to work in the mines.");

            var workResult = WorkResult.Success;
            player.ReduceEnergy(this.EnergyRequirement);
            player.EarnMoney(this.Wage);
            player.ReduceHappiness(this.HappinessEffect);

            CheckForInjury(player, workResult);

            DomainEvents.Raise<PlayerWorkedEvent>(new PlayerWorkedEvent(player, this));

            return workResult;
        }

        private static void CheckForInjury(Player player, WorkResult workResult)
        {
            var injuryRoll = new Random().Next(1, 100);

            // 1% chance of major injury
            if (injuryRoll <= 1)
            {
                player.ReduceHealth(20);
                workResult.AddMessage("You suffered a major injury in the mines.");
            }
            // 4% chance of minor injury
            else if (injuryRoll <= 5)
            {
                player.ReduceHealth(5);
                workResult.AddMessage("You had a minor injury in the mines.");
            }
            // 95% chance of no injury
            else
            {

            }
        }

    }
}
