using SearchingApp.DDD.Entities.Shared;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.Specification;
using System.Collections.Generic;
using System.Linq;

namespace SearchingApp.Application.Specifications
{
    public class UserTechnologySpecification : BaseSpecification<User>
    {
        public UserTechnologySpecification(List<Technology> technologies)
        {
            // if (!(technologies is null))
            // {
            //     Criteria = ct => ct.Technologies.Where(x => technologies.Any(z => z.TechnologyPart == x.TechnologyPart)).Any();
            // }

        }
    }

    public static class UserTechnologySpecificationExtension
    {
        public static IQueryable<User> ForTechnologies(this IQueryable<User> query, List<Technology> technologies)
        {
            return query.Where(new UserTechnologySpecification(technologies));
        }
    }
}
