using Capitalism.SharedKernel.Model;

namespace Capitalism.Logic.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(string id);
    }
}
