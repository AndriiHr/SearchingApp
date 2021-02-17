using SearchingApp.DDD.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchingApp.Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetAll();
        Task AssignProjectToUser(int userId, int projectId);
    }
}
