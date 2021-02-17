using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands
{
    public class DeleteUserRequest : IRequest
    {
        public int UserId { get; set; }
    }

    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly EFContext _efContext;
        public DeleteUserRequestHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _efContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            user.IsActive = false;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
