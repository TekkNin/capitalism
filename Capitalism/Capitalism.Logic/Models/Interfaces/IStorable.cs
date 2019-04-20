namespace Capitalism.Logic.Models.Interfaces
{
    public interface IStorable
    {
        /// <summary>
        /// The unique foreign key identifier for what owns the inventory
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Items that in possession of the company or player. These items are lost upon death or bankruptcy.
        /// </summary>
        Inventory Inventory { get; }

    }
}
