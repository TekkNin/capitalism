using Capitalism.Logic.Events;
using Capitalism.Logic.Events.BuildingEvents;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.Logic.Models.Items;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;
using System.Linq;

namespace Capitalism.Logic.Models.Buildings
{
    /// <summary>
    /// The forest is a goverment controlled building type that allows players to get basic construction materials, but with a lot of effort. 
    /// This allows players to start constructing other types of buildings without any skills
    /// </summary>
    public class Forest : WritableEntity, IMappable, IWorkable, IStorable
    {
        private const int MAX_FOREST_SIZE = 1000;

        public string TownId { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name => "Forest";
        public string Image => "tree";

        public int EnergyRequirement => 10;
        public int Wage => 0;

        public Inventory Inventory { get; private set; }

        public Forest(string id, string townId, int xCoordinate, int yCoordinate, DateTime modifiedDate, DateTime createdDate) :
            base(id, modifiedDate, createdDate)
        {
            this.TownId = townId;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Inventory = new Inventory();
        }

        public ActionResults Work(Player player)
        {
            if (!player.IsAlive)
                return ActionResults.Failed("You're dead.");
            if (this.Inventory?.Items?.FirstOrDefault()?.Quantity == 0)
                return ActionResults.Failed("All the mature trees are gone. Wait for them to grow.");
            if (player.Energy < this.EnergyRequirement)
                return ActionResults.Failed("You don't have enough energy to work in the forest.");

            var workResults = ActionResults.Success("You gather some wood in the forest.");
            player.ReduceEnergy(this.EnergyRequirement);
            player.EarnMoney(this.Wage);

            player.Inventory.AddItem(1, new BasicBuildingMaterial());
            ReduceTreeCount();

            CheckForInjury(player, workResults);

            DomainEvents.Raise(new PlayerWorkedEvent(player, this));
            DomainEvents.Raise(new ForestWorkedEvent(this));

            return workResults;
        }

        /// <summary>
        /// Increases the number of trees in the forest
        /// </summary>
        /// <param name="additionalTreesQuantity">The number of additional trees that are available</param>
        public void IncreaseTreeCount(int additionalTreesQuantity)
        {
            if (this.Inventory?.Items == null || this.Inventory.Items.Count() == 0)
            {
                this.Inventory = new Inventory();
                this.Inventory.AddItem(0, new BasicBuildingMaterial());
            }

            this.Inventory.Items.First().IncreaseQuantity(additionalTreesQuantity);

            if (this.Inventory.Items.First().Quantity > MAX_FOREST_SIZE)
                this.Inventory.Items.First().SetQuantity(MAX_FOREST_SIZE);
        }

        private void ReduceTreeCount()
        {
            if (this.Inventory?.Items == null || this.Inventory.Items.Count() == 0)
            {
                this.Inventory = new Inventory();
                this.Inventory.AddItem(0, new BasicBuildingMaterial());
            }

            this.Inventory.Items.First().ReduceQuantity(1);
        }

        private void CheckForInjury(Player player, ActionResults workResults)
        {
            var injuryRoll = new Random().Next(1, 100);

            // 1% chance of minor injury
            if (injuryRoll <= 1)
            {
                player.ReduceHealth(5);
                workResults.AddResult(ActionResult.Warning("You had a minor injury in the forest."));
            }
            // 95% chance of no injury
            else
            {

            }
        }

    }
}
