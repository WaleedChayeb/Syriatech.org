using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Links.Queries.GetLink
{
    public class GetLinkQueryHandler : IRequestHandler<GetLinkQuery, LinkViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;
 
        public GetLinkQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LinkViewModel> Handle(GetLinkQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LinkViewModel>(await _context
            .Links.Where(p => p.LinkId == request.Id)
            .SingleOrDefaultAsync(cancellationToken));

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            entity.EditEnabled = true;
            entity.DeleteEnabled = false;

            return entity;
        }
    }
}
