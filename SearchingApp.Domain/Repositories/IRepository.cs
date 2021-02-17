using SearchingApp.DDD.Entities.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByid(int id);
        Task Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity);
        Task Remove(int id);
    }
}
