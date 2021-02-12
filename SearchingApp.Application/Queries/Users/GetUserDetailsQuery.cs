using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Application.Specifications;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Queries.Users
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsResponse>
    {
        public long UserId { get; set; }
    }

    public class GetUserDetailsResponse
    {
        public User User { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResponse>
    {
        private readonly EFContext _dbContext;

        public GetUserDetailsQueryHandler(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users
                        .GetActiveUsers()
                        .ForUser(request.UserId)
                        .Include(x => x.Projects)
                        .ThenInclude(x => x.Opinions)
                        .Select(x => new GetUserDetailsResponse()
                        {
                            User = x,
                            Projects = x.Projects.ToList()

                        }).FirstOrDefaultAsync();

            return result;
        }
    }
}
