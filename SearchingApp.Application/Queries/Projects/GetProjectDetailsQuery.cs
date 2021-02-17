using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Queries.Projects
{
    public class GetProjectDetailsQuery : IRequest<GetActiveUsersResponse>
    {
        public int ProjectId { get; set; }
    }

    public class GetActiveUsersResponse
    {
        public Project Project { get; set; }
    }

    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, GetActiveUsersResponse>
    {
        private readonly EFContext _dbContext;

        public GetProjectDetailsQueryHandler(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetActiveUsersResponse> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);
            var response = new GetActiveUsersResponse()
            {
                Project = result
            };

            return response;
        }
    }

}
