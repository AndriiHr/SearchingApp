using SearchingApp.DDD.Entities.User;
using System.Threading.Tasks;

namespace SearchingApp.Domain.Repositories
{
    public interface IOpinionRepository : IRepository<Opinion>
    {
        Task AssingOpinionToProject(Opinion opinion, int projectId);
    }
}
