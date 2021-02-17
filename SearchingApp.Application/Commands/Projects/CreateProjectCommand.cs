using MediatR;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Projects
{
    public class CreateProjectCommand : IRequest
    {
        public Project Project { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly EFContext _efContext;

        public CreateProjectCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {        
            _efContext.Projects.Add(request.Project);
            await _efContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
