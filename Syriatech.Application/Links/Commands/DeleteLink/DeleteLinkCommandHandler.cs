using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;

namespace Syriatech.Application.Links.Commands.DeleteLink
{
    public class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand>
    {
        private readonly ISyriatechDbContext _context;

        public DeleteLinkCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Links.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            } 

            _context.Links.Remove(entity); 
            await _context.SaveChangesAsync(cancellationToken); 
            return Unit.Value;
        }
    }
}
