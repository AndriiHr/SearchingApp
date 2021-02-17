using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Projects
{
    public class DeleleProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
    }

    public class DeleteOpinionCommandHandler : IRequestHandler<DeleleProjectCommand>
    {
        private readonly EFContext _efContext;
        public DeleteOpinionCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(DeleleProjectCommand request, CancellationToken cancellationToken)
        {
            var user = await _efContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);
            user.IsActive = false;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}



