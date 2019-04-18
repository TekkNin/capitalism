using Capitalism.Logic.Models;
using System.Collections.Generic;

namespace Capitalism.Logic.Repositories
{
    public interface IPlayerRepository : IRepository<Player>, IRepositoryWriteable<Player>
    {
        /// <summary>
        /// Retrieves all the players in the game
        /// </summary>
        /// <returns>All players in the game</returns>
        IEnumerable<Player> GetAll();
        
        /// <summary>
        /// Retreives the player associated with a specific user
        /// </summary>
        /// <param name="userId">The unique foreign key identifier for the account that this player belongs.</param>
        /// <returns>The player associated with the account</returns>
        Player GetByUserId(string userId);

        /// <summary>
        /// Only updates the players stats and skills, does not update inventory
        /// </summary>
        /// <param name="player"></param>
        void UpdateStats(Player player);
    }
}
