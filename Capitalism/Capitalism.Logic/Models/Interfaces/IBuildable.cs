using Capitalism.Logic.Models.Buildings;
using Capitalism.Logic.Models.Items;
using Capitalism.Logic.Types;
using System.Collections.Generic;

namespace Capitalism.Logic.Models.Interfaces
{
    public interface IBuildable
    {
        /// <summary>
        /// The materials required by the player to construct the building
        /// </summary>
        IEnumerable<InventoryItem> BuildMaterials { get; }

        /// <summary>
        /// Builds a new building type on empty land
        /// </summary>
        /// <param name="emptyLand">The land being built on</param>
        /// <param name="player">The player who owns the land and is building the new building</param>
        /// <returns>Whether constuction was successful or not and the reason why</returns>
        ActionResults Build(EmptyLand emptyLand, Player player);
    }
}
