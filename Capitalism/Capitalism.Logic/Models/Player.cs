using Capitalism.Logic.Events;
using Capitalism.Logic.Models.Interfaces;
using Capitalism.SharedKernel.Events;
using Capitalism.SharedKernel.Model;
using System;

namespace Capitalism.Logic.Models
{
    public class Player : WritableEntity, IStorable
    {
        /// <summary>
        /// The unique foreign key identifier for the account that this player belongs.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// The unique foreign key identifier for which town the player is currently located.
        /// </summary>
        public string CurrentTown { get; private set; }

        /// <summary>
        /// The name the player would like displayed to everyone else.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            private set
            {
                _displayName = value.Trim();
                this.SetModifiedDate();
            }
        }
        private string _displayName;

        /// <summary>
        /// The number of health points a player has (between 0 and 100). Health determines if the player is alive or not.
        /// </summary>
        public int Health
        {
            get { return _health; }
            private set
            {
                if (value < 0) _health = 0;
                else if (value > 100) _health = 100;
                else _health = value;
            }
        }
        private int _health;

        /// <summary>
        /// Returns whether the player is alive (health isn't zero)
        /// </summary>
        public bool IsAlive => this.Health > 0;

        /// <summary>
        /// The amount of energy a player has (between 0 and 100). Energy is required to perform actions in the game.
        /// </summary>
        public int Energy
        {
            get { return _energy; }
            private set
            {
                if (value < 0) _energy = 0;
                else if (value > 100) _energy = 100;
                else _energy = value;
            }
        }
        private int _energy;

        /// <summary>
        /// How happy the player is (between 0 and 100). Happiness can affect the outcome of certain actions within the game.
        /// </summary>
        public int Happiness
        {
            get { return _happiness; }
            private set
            {
                if (value < 0) _happiness = 0;
                else if (value > 100) _happiness = 100;
                else _happiness = value;
            }
        }
        private int _happiness;

        /// <summary>
        /// Value of the player's luxeries. Esentially this is the player's score.
        /// </summary>
        public int Swagger
        {
            get { return _swagger; }
            private set
            {
                if (value < 0) _swagger = 0;
                else _swagger = value;
            }
        }
        private int _swagger;

        /// <summary>
        /// How much money the player has on-hand. This money is lost upon death.
        /// </summary>
        public long MoneyOnHand
        {
            get { return _moneyOnHand; }
            private set
            {
                if (value < 0) _moneyOnHand = 0;
                else _moneyOnHand = value;
            }
        }
        private long _moneyOnHand;

        /// <summary>
        /// A player's ability to perform certain types of tasks depends on their skills.
        /// </summary>
        public Skills Skills { get; private set; }

        /// <summary>
        /// Items that a player has on-hand. These items are lost upon death.
        /// </summary>
        public Inventory Inventory { get; private set; }
        public void InitializeInventory() => this.Inventory = new Inventory();

        private Player() : base()
        {
            this.InitializeInventory();
        }

        public Player(
            string id,
            string userId,
            string townId,
            string displayName,
            int health,
            int energy,
            int happiness,
            int swagger,
            long moneyOnHand,
            Skills skills,
            DateTime modifiedDate,
            DateTime createdDate) :
            base(id, modifiedDate, createdDate)
        {
            this.UserId = userId;
            this.CurrentTown = townId;
            this.DisplayName = displayName;
            this.Health = health;
            this.Energy = energy;
            this.Happiness = happiness;
            this.Swagger = swagger;
            this.MoneyOnHand = moneyOnHand;
            this.Skills = skills;
            this.Inventory = new Inventory();
        }

        /// <summary>
        /// Creates a new player with default stats for a user.
        /// </summary>
        /// <param name="userId">The unique foreign key identifier for the account that this player belongs.</param>
        /// <param name="displayName">The name the player would like displayed to everyone else.</param>
        /// <returns>A new player object with default stats.</returns>
        public static Player CreateNewPlayer(string userId, string displayName)
        {
            var player = new Player();
            player.UserId = userId;
            player.DisplayName = displayName;
            player.Health = 100;
            player.Energy = 100;
            player.Happiness = 100;
            player.Swagger = 0;
            player.MoneyOnHand = 0;
            player.Skills = Skills.Default;

            DomainEvents.Raise<PlayerCreatedEvent>(new PlayerCreatedEvent(player));

            return player;
        }

        /// <summary>
        /// Increases the players health points, max 100.
        /// </summary>
        /// <param name="healthPoints">A number indicating the number of health points to increase. If a negative is provided the absolute value is used.</param>
        public void AddHealth(int healthPoints)
        {
            this.Health += Math.Abs(healthPoints);
        }

        /// <summary>
        /// Reduces the players health points down, min 0.
        /// </summary>
        /// <param name="healthPoints">A number indicating the number of health points to decrease. If a negative is provided the absolute value is used.</param>
        public void ReduceHealth(int healthPoints)
        {
            this.Health -= Math.Abs(healthPoints);
        }

        /// <summary>
        /// Increases the player's energy, max 100.
        /// </summary>
        /// <param name="energyPoints">A number indicating the amount of energy to increase. If a negative is provided the absolute value is used.</param>
        public void AddEnergy(int energyPoints)
        {
            this.Energy += Math.Abs(energyPoints);
        }

        /// <summary>
        /// Reduces the player's energy down, min 0.
        /// </summary>
        /// <param name="energyPoints">A number indicating the amount of energy to decrease. If a negative is provided the absolute value is used.</param>
        public void ReduceEnergy(int energyPoints)
        {
            this.Energy -= Math.Abs(energyPoints);
        }

        /// <summary>
        /// Increases the player's happiness, max 100.
        /// </summary>
        /// <param name="happinessPoints">A number indicating the amount of happiness to increase. If a negative is provided the absolute value is used.</param>
        public void AddHappiness(int happinessPoints)
        {
            this.Happiness += Math.Abs(happinessPoints);
        }

        /// <summary>
        /// Reduces the player's energy down, min 0.
        /// </summary>
        /// <param name="happinessPoints">A number indicating the amount of happiness to decrease. If a negative is provided the absolute value is used.</param>
        public void ReduceHappiness(int happinessPoints)
        {
            this.Happiness -= Math.Abs(happinessPoints); ;
        }

        /// <summary>
        /// Increases the amount of money on hand for a player.
        /// </summary>
        /// <param name="moneyEarned">A number indicating the amount of money earned. If a negative is provided the absolute value is used.</param>
        public void EarnMoney(int moneyEarned)
        {
            this.MoneyOnHand += Math.Abs(moneyEarned);
        }

        /// <summary>
        /// Change the town that a player is currently located.
        /// </summary>
        /// <param name="townId">The unique foreign key identifier of the town the player is moving to.</param>
        public void SetTown(string townId)
        {
            this.CurrentTown = townId;
        }

        
    }
}
