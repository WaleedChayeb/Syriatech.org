using MediatR;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly ISyriatechDbContext _context;

        public CreateProjectCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }
         
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project
            {
                CreateDate = DateTime.Now,
                Description = request.Description,
                CreateBy = request.CreateBy,
                Title = request.Title,
                Url = request.Url
            };

            _context.Projects.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProjectId;
        }
    }
}
