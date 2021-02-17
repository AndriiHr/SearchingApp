using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands
{
    public class EditUserRequest : IRequest
    {
        public User User { get; set; }
    }


    public class EditUserRequestHandler : IRequestHandler<EditUserRequest>
    {
        private EFContext _efContext;
        public EditUserRequestHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            _efContext.Entry(request.User).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
