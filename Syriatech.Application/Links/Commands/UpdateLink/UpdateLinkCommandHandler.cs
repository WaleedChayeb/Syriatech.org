using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Links.Commands.UpdateLink
{
    public class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, Unit>
    {
        private readonly ISyriatechDbContext _context;

        public UpdateLinkCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Links.FindAsync(request.LinkId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.LinkId);
            }

            entity.LinkId = entity.LinkId;
            entity.Type = request.Type;
            entity.Value = request.Value; 
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
