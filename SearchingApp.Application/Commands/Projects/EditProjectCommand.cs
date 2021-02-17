using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Projects
{
    public class EditProjectCommand : IRequest
    {
        public Project Project { get; set; }
    }

    public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand>
    {
        private EFContext _efContext;
        public EditProjectCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            _efContext.Entry(request.Project).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
