using MediatR;
using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.User;
using SearchingApp.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingApp.Application.Commands.Opinions
{
    public class AssingOpinionToProjectCommand : IRequest
    {
        public int PorjectId { get; set; }
        public Opinion Opinion { get; set; }
    }


    public class AssingOpionionToProjectCommandHandler : IRequestHandler<AssingOpinionToProjectCommand>
    {
        private readonly EFContext _efContext;

        public AssingOpionionToProjectCommandHandler(EFContext efContext)
        {
            _efContext = efContext;
        }

        public async Task<Unit> Handle(AssingOpinionToProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _efContext.Projects.FirstOrDefaultAsync(x => x.Id == request.PorjectId);
            project.AddOpinion(request.Opinion);

            _efContext.Entry(project).State = EntityState.Modified;
            await _efContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
