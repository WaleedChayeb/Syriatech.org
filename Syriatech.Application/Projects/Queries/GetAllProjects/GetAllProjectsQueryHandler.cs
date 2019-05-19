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

namespace Syriatech.Application.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, ProjectsListViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectsListViewModel> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Projects.OrderBy(p => p.CreateDate).ToListAsync(cancellationToken);

            var model = new ProjectsListViewModel
            {
                Projects = _mapper.Map<IEnumerable<ProjectDto>>(products),
                CreateEnabled = true
            };

            return model;
        }
    }
}
