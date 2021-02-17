using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;

namespace SearchingApp.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public User User { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly EFContext _efContext;

        public CreateUserCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.SetPassword(request.Password);
            _efContext.Users.Add(request.User);

            await _efContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}