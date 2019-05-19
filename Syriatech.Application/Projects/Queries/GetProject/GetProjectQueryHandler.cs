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

namespace Syriatech.Application.Projects.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;
 
        public GetProjectQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProjectViewModel>(await _context
            .Projects.Where(p => p.ProjectId == request.Id)
            .SingleOrDefaultAsync(cancellationToken));

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            entity.EditEnabled = true;
            entity.DeleteEnabled = false;

            return entity;
        }
    }
}
