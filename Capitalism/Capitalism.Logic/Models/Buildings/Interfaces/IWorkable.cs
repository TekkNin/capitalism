using Capitalism.Logic.Types;

namespace Capitalism.Logic.Models.Buildings
{
    public interface IWorkable
    {
        /// <summary>
        /// The amount of energy required to perform the work, the players energy will be reduced by this amount
        /// </summary>
        int EnergyRequirement { get; }
        
        /// <summary>
        /// The amount of money earned for performning the work
        /// </summary>
        int Wage { get; }

        /// <summary>
        /// Executes a unit of work, checks for skill requirements, reduces stats, and earns a wage
        /// </summary>
        /// <param name="player">The player performing the work</param>
        /// <returns>The results of whether the work was successfully performed and any reasons why it wasn't</returns>
        WorkResult Work(Player player);
    }

    
}
