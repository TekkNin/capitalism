using Capitalism.Logic.Types;

namespace Capitalism.Logic.Models.Interfaces
{
    public interface IOwnable : IMappable
    {
        /// <summary>
        /// The foreign key identifier for who currently owns the building. If this is null, the government owns the building.
        /// </summary>
        string OwnerId { get; }

        /// <summary>
        /// Whether the building is currently avaible for purchase by other players
        /// </summary>
        bool IsForSale { get; }

        /// <summary>
        /// If the building is for sale, this is the requested purchase price
        /// </summary>
        int? Price { get; }

        /// <summary>
        /// Transfer ownership of a building from the previous owner to the new owner, and transfers money equal to the purchase price to the previous owner
        /// </summary>
        /// <param name="purchasingPlayer">The player purchasing the building</param>
        /// <returns>Whether the purchase was successful or not and the reason why</returns>
        ActionResults Purchase(Player purchasingPlayer);

        /// <summary>
        /// Sets the ownerId of the building
        /// </summary>
        /// <param name="playerId">The player id of the new owner</param>
        void SetOwner(string playerId);
    }
}
