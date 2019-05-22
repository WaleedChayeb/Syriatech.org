using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Projects.Queries.GetAllProjects;

namespace Syriatech.WebUI.Controllers
{
    public class LoveSyriaController : NormalBaseController
    {
        public async Task<IActionResult> Index()
        {
            var projects = new ProjectsListViewModel();
            try
            {

                var result = Ok(await Mediator.Send(new GetAllProjectsQuery()));
                projects = ((ProjectsListViewModel)result.Value);


            }
            catch (Exception e)
            {

            }

            return View(projects);
        }
    }
}