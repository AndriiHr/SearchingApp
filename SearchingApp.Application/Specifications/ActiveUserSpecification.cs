using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.Specification;
using System.Linq;

namespace SearchingApp.Application.Specifications
{
    public class ActiveUserSpecification: BaseSpecification<User>
    {
        public ActiveUserSpecification()
        {
            Criteria = ct => ct.IsActive;
        }
    }

    public static class ActiveUserSpecificationExtension
    {
        public static IQueryable<User> GetActiveUsers(this IQueryable<User> query)
        {
            return query.Where(new ActiveUserSpecification());
        }
    }
}
