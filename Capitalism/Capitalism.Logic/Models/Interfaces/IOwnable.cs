namespace Capitalism.Logic.Models.Interfaces
{
    public interface IOwnable
    {
        string OwnerId { get; }
        bool IsForSale { get; }
        int? Price { get; }
    }
}
