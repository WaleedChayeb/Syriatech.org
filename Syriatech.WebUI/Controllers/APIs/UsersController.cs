using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Users.Queries.GetAllUsers;
using Syriatech.Application.Users.Queries.GetUser;

namespace Syriatech.WebUI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserViewModel>> Get(string username)
        {
            return Ok(await Mediator.Send(new GetUserQuery { Username = username }));
        }
    }
}