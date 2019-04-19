namespace Capitalism.Logic.Models.Buildings
{
    public interface IMappable
    {
        /// <summary>
        /// The unique identifier for the building
        /// </summary>
        string Id { get; }

        /// <summary>
        /// There will be multiple towns. This is the unique foreign key identifier for the town this building is located
        /// </summary>
        string TownId { get; }

        /// <summary>
        /// The x position on the map to find this building (starts at zero)
        /// </summary>
        int XCoordinate { get; }

        /// <summary>
        /// The y position on the map to find this building (starts at zero)
        /// </summary>
        int YCoordinate { get; }

        /// <summary>
        /// The name of the building
        /// </summary>
        string Name { get; }
    }
}
