using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands
{
    public class AssignUserToProjectCommand : IRequest
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }


    public class AssignUserToProjectCommandHandler : IRequestHandler<AssignUserToProjectCommand>
    {
        private readonly EFContext _efContext;

        public AssignUserToProjectCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(AssignUserToProjectCommand request, CancellationToken cancellationToken)
        {
            var user = await _efContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            var project = await _efContext.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);

            user.AssignProjectToUser(project);

            _efContext.Entry(user).State = EntityState.Modified;
            await _efContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
