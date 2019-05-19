using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;

namespace Syriatech.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly ISyriatechDbContext _context;

        public DeleteEventCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            } 

            _context.Events.Remove(entity); 
            await _context.SaveChangesAsync(cancellationToken); 
            return Unit.Value;
        }
    }
}
