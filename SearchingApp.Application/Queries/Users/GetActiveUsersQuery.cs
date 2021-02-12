using MediatR;
using SearchingApp.Application.Specifications;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.Shared;

namespace SearchingApp.Application.Queries.Users
{
    public class GetActiveUsersQuery : IRequest<List<GetActiveUsersResponse>>
    {
        public List<Technology> Technologies { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
    }

    public class GetActiveUsersResponse
    {
        public User User { get; set; }
    }

    public class GetActiveUsersQueryHandler : IRequestHandler<GetActiveUsersQuery, List<GetActiveUsersResponse>>
    {
        private readonly EFContext _dbContext;

        public GetActiveUsersQueryHandler(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetActiveUsersResponse>> Handle(GetActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Users.GetActiveUsers()
                .ForTechnologies(request.Technologies)
                .Select(x => new GetActiveUsersResponse() { User = x })
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
