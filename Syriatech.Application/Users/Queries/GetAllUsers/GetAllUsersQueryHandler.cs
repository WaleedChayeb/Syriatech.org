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

namespace Syriatech.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersListViewModel>
    {
        private readonly ISyriatechDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(ISyriatechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersListViewModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await  _context.Users.OrderBy(p => p.YearsOfExperience).ToListAsync(cancellationToken);
            var model = new UsersListViewModel
            {
                Users = _mapper.Map<IEnumerable<UserDto>>(users)
            };

            return model;
        }
    }
}
