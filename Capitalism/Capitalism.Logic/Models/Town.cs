using System;
using Capitalism.SharedKernel.Model;

namespace Capitalism.Logic.Models
{
    public class Town : WritableEntity
    {
        /// <summary>
        /// The name of the town
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The number of players currently in the town, includes inactive players
        /// </summary>
        public int Population { get; private set; }

        /// <summary>
        /// The amount of money the town currently has to spend on government initiatives
        /// </summary>
        public long AccountBalance { get; private set; }

        /// <summary>
        /// The amount of pollution in the air (0 being perfectly clean air). Improved by the forest, worsen by using coal.
        /// </summary>
        public int PollutionLevel {
            get { return _pollutionLevel; }
            private set
            {
                if (value < 0) _pollutionLevel = 0;
                else _pollutionLevel = value;
            }
        }
        private int _pollutionLevel;

        public Town(string id, string name, int population, long accountBalance, int pollutionLevel, DateTime modifiedDate, DateTime createdDate) : 
            base(id, modifiedDate, createdDate)
        {
            Name = name;
            Population = population;
            AccountBalance = accountBalance;
            PollutionLevel = pollutionLevel;
        }

        /// <summary>
        /// Increaes the population by 1
        /// </summary>
        public void AddCitizen() => this.Population++;

        /// <summary>
        /// Increases the amount of money on the town has available.
        /// </summary>
        /// <param name="moneyEarned">A number indicating the amount of money collected. If a negative is provided the absolute value is used.</param>
        public void IncreaseAccountBalance(int revenue) => this.AccountBalance += Math.Abs(revenue);

    }
}
