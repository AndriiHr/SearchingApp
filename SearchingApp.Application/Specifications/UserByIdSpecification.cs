using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.Specification;
using System.Linq;

namespace SearchingApp.Application.Specifications
{
    public class UserByIdSpecification: BaseSpecification<User>
    {
        public UserByIdSpecification(long id)
        {
            Criteria = s => s.Id == id;
        }
    }

    public static class UserByIdSpecificationExtension
    {
        public static IQueryable<User> ForUser(this IQueryable<User> query, long userId)
        {
            return query.Where(new UserByIdSpecification(userId));
        }
    }
}
