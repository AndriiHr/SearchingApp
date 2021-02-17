using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Queries.Opinions
{
    public class GetProjectOpinionsQuery : IRequest<GetProjectOpinionsResponse>
    {
        public int ProjectId { get; set; }
    }

    public class GetProjectOpinionsResponse
    {
        public List<Opinion> Opinions { get; set; }
    }

    public class GetProjectOpinionsQueryHandler : IRequestHandler<GetProjectOpinionsQuery, GetProjectOpinionsResponse>
    {
        private readonly EFContext _efContext;
        public GetProjectOpinionsQueryHandler(EFContext context)
        {
            _efContext = context;
        }

        public async Task<GetProjectOpinionsResponse> Handle(GetProjectOpinionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _efContext.Projects.Include(op => op.Opinions).FirstOrDefaultAsync(x => x.Id == request.ProjectId);
            var result = new GetProjectOpinionsResponse()
            {
                Opinions = response.Opinions.ToList()
            };

            return result;
        }
    }
}
