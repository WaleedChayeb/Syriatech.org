using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Syriatech.Application.Exceptions;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks; 



namespace Syriatech.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UserViewModel>(await _context
            .Users.Where(p => p.FirstName == request.Username)
            .SingleOrDefaultAsync(cancellationToken));

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request);
            }

            return entity;
        }
    }
}
