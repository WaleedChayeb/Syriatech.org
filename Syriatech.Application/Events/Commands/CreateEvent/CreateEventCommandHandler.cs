using MediatR;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly ISyriatechDbContext _context;

        public CreateEventCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }
         
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event
            {
                CreateDate = DateTime.Now,
                Description = request.Description,
                EndDate = request.EndDate,
                Organizer = request.Organizer,
                StartDate = request.StartDate,
                Title = request.EventTitle,
                Url = request.Url
            };

            _context.Events.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.EventId;
        }
    }
}
