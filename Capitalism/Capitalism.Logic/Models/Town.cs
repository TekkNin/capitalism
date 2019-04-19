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

        public Town(string id, string name, int population, int pollutionLevel, DateTime modifiedDate, DateTime createdDate) : 
            base(id, modifiedDate, createdDate)
        {
            Name = name;
            Population = population;
            PollutionLevel = pollutionLevel;
        }

        /// <summary>
        /// Increaes the population by 1
        /// </summary>
        public void AddCitizen()
        {
            this.Population++;
        }
        
    }
}
