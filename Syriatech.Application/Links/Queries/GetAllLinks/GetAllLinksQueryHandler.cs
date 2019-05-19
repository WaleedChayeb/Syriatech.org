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

namespace Syriatech.Application.Links.Queries.GetAllLinks
{
    public class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, LinksListViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;

        public GetAllLinksQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LinksListViewModel> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
        {
            var links = await _context.Links.OrderBy(p => p.CreatedBy == request.Username).ToListAsync(cancellationToken);

            var model = new LinksListViewModel
            {
                Links = _mapper.Map<IEnumerable<LinkDto>>(links),
                CreateEnabled = true
            };

            return model;
        }
    }
}
