using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Domain.Repositories;
using SearchingApp.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly EFContext _efContext;
        public UserRepository(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task AssignUserToProject(int userId, int projectId)
        {
            var user = await GetByid(userId);
        }

        public async Task<IEnumerable<User>> GetActive()
        {
            return await _efContext.Users.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<User> GetByid(int id)
        {
            return await _efContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(User entity, CancellationToken cancellationToken)
        {
            await _efContext.AddAsync(entity);
            await _efContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Remove(int id)
        {
            var user = await GetByid(id);
            user.IsActive = false;
            _efContext.Entry(user).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _efContext.Entry(entity).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();
        }
    }
}
