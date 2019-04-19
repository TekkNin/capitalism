using Capitalism.Logic.Models;

namespace Capitalism.Logic.Repositories
{
    public interface ITownRepository : IRepository<Town>, IRepositoryWriteable<Town>
    {
        Town GetSmallestTown();
    }
}
