using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Projects.Queries.GetAllProjects;
using Syriatech.Application.Projects.Queries.GetProject;

namespace Syriatech.WebUI.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProjectsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProjectQuery { Id = id }));
        }
    }
}