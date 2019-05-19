using MediatR;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly ISyriatechDbContext _context;

        public UpdateProjectCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.ProjectId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.ProjectId);
            }
             
            entity.Title = request.Title;
            entity.Url = request.Url;
            entity.Description = request.Description; 

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
