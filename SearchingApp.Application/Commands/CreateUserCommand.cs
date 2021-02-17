using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Domain.Repositories;
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
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.SetPassword(request.Password);
            await _repository.Add(request.User, cancellationToken);

            return Unit.Value;
        }
    }
}