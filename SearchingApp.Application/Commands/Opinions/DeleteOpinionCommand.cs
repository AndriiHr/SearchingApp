using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Opinions
{
    public class DeleteOpinionCommand: IRequest
    {
        public int OpinionId { get; set; }
    }


    public class DeleteOpinionCommandHandler : IRequestHandler<DeleteOpinionCommand>
    {
        private readonly EFContext _efContext;
        public DeleteOpinionCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(DeleteOpinionCommand request, CancellationToken cancellationToken)
        {
            var user = await _efContext.Opinions.FirstOrDefaultAsync(x => x.Id == request.OpinionId);
            user.IsActive = false;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
