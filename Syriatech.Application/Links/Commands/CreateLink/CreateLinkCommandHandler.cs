using MediatR;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syriatech.Application.Links.Commands.CreateLink
{
    public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, int>
    {
        private readonly ISyriatechDbContext _context;

        public CreateLinkCommandHandler(ISyriatechDbContext context)
        {
            _context = context;
        }
         
        public async Task<int> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
        {
            var entity = new Link
            {
                CreateDate = DateTime.Now,
                CreatedBy = request.CreatedBy,
                Type = request.Type,
                Value = request.Value
            };

            _context.Links.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.LinkId;
        }
    }
}
