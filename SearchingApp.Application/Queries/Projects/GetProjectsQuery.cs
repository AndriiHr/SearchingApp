using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Queries.Projects
{
    public class GetProjectsQuery : IRequest<List<GetProjectResponse>>
    {
    }
    public class GetProjectResponse
    {
        public Project Project { get; set; }
    }

    public class GetActiveUsersQueryHandler : IRequestHandler<GetProjectsQuery, List<GetProjectResponse>>
    {
        private readonly EFContext _efContext;
        public GetActiveUsersQueryHandler(EFContext context)
        {
            _efContext = context;
        }

        public async Task<List<GetProjectResponse>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _efContext.Projects.Select(x => new GetProjectResponse() { Project = x }).ToListAsync();

            return result;
        }
    }
}
