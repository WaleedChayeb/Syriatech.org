using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly ISyriatechDbContext _context;

        public UpdateEventCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.EventId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            entity.EventId = request.EventId;
            entity.Organizer = request.Organizer;
            entity.StartDate = request.StartDate;
            entity.Title = request.EventTitle;
            entity.Url = request.Url;
            entity.Description = request.Description;
            entity.EndDate = request.EndDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
