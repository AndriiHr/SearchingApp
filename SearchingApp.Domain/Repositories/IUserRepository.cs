using SearchingApp.DDD.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchingApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetActive();
        Task AssignUserToProject(int userId, int projectId);
    }
}
