using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Queries.Opinions
{
    public class GetOpinionDetailsQuery: IRequest<GetOpinionResponse>
    {
        public int OpinionId { get; set; }
    }

    public class GetOpinionResponse
    {
        public Opinion Opinion { get; set; }
    }

    public class GetOpinionQueryHandler : IRequestHandler<GetOpinionDetailsQuery, GetOpinionResponse>
    {
        private readonly EFContext _efContext;
        public GetOpinionQueryHandler(EFContext context)
        {
            _efContext = context;
        }

        public async Task<GetOpinionResponse> Handle(GetOpinionDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = await _efContext.Opinions.FirstOrDefaultAsync(x => x.Id == request.OpinionId);

            var result = new GetOpinionResponse()
            {
                Opinion = response
            };

            return result;
        }
    }
}
