using Capitalism.Logic.Events;
using Capitalism.Logic.Models.Interfaces;
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
        public string Image => "mountain";
        public string Name => "Mine";

        public int EnergyRequirement => 20;
        public int HappinessEffect => -5;
        public int Wage => 5;        

        public Mine(string id, string townId, int xCoordinate, int yCoordinate, DateTime modifiedDate, DateTime createdDate) :
            base(id, modifiedDate, createdDate)
        {
            this.TownId = townId;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public ActionResults Work(Player player)
        {
            if (!player.IsAlive)
                return ActionResults.Failed("You're dead.");
            if (player.Energy < this.EnergyRequirement)
                return ActionResults.Failed("You don't have enough energy to work in the mines.");

            var workResults = ActionResults.Success($"You earn ${this.Wage} working in the mines.");
            player.ReduceEnergy(this.EnergyRequirement);
            player.EarnMoney(this.Wage);
            player.ReduceHappiness(this.HappinessEffect);

            CheckForInjury(player, workResults);

            DomainEvents.Raise<PlayerWorkedEvent>(new PlayerWorkedEvent(player, this));

            return workResults;
        }

        private void CheckForInjury(Player player, ActionResults workResults)
        {
            var injuryRoll = new Random().Next(1, 100);

            // 1% chance of major injury
            if (injuryRoll <= 1)
            {
                player.ReduceHealth(20);
                workResults.AddResult(ActionResult.Warning("You suffered a major injury in the mines."));
            }
            // 4% chance of minor injury
            else if (injuryRoll <= 5)
            {
                player.ReduceHealth(5);
                workResults.AddResult(ActionResult.Warning("You suffered a minor injury in the mines."));
            }
            // 95% chance of no injury
            else
            {

            }
        }

    }
}
