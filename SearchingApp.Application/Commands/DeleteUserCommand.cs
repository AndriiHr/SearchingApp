using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly EFContext _efContext;
        public DeleteUserCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _efContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            user.IsActive = false;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
