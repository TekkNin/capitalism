namespace Capitalism.Logic.Models.Buildings
{
    public interface IOwnable
    {
        string OwnerId { get; }
        bool IsForSale { get; }
        int Price { get; }
    }
}
