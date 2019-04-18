using Capitalism.SharedKernel.Model;

namespace Capitalism.Logic.Repositories
{
    public interface IRepositoryWriteable<TEntity> where TEntity : WritableEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
