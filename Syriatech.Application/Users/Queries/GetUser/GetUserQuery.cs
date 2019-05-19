using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public string Username { get; set; }
    }
}
