using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Syriatech.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, EventsListViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventsListViewModel> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Events.OrderBy(p => p.CreateDate).ToListAsync(cancellationToken);

            var model = new EventsListViewModel
            {
                Events = _mapper.Map<IEnumerable<EventDto>>(products),
                CreateEnabled = true
            };

            return model;
        }
    }
}
