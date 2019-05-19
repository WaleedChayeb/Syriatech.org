using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;

namespace Syriatech.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly ISyriatechDbContext _context;

        public DeleteProjectCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            } 

            _context.Projects.Remove(entity); 
            await _context.SaveChangesAsync(cancellationToken); 
            return Unit.Value;
        }
    }
}
