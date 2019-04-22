using Capitalism.Logic.Models.Items;
using System.Collections.Generic;

namespace Capitalism.Logic.Models.Interfaces
{
    public interface IBuildable
    {
        /// <summary>
        /// The materials required by the player to construct the building
        /// </summary>
        IEnumerable<IItemCollectable> BuildMaterials { get; }

        // TODO: Define build
        void Build(Player player);
    }
}
