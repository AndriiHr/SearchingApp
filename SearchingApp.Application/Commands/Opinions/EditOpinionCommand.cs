using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Opinions
{
    public class EditOpinionCommand : IRequest
    {
        public Opinion Opinion { get; set; }
    }

    public class EditOpinionCommandHandler : IRequestHandler<EditOpinionCommand>
    {
        private EFContext _efContext;
        public EditOpinionCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(EditOpinionCommand request, CancellationToken cancellationToken)
        {
            _efContext.Entry(request.Opinion).State = EntityState.Modified;
            await _efContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
